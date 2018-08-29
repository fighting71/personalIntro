package game.monster.com.monstergame.extension.view;

import android.content.Context;
import android.content.res.TypedArray;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Matrix;
import android.graphics.Paint;
import android.graphics.Path;
import android.graphics.RectF;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.Drawable;
import android.media.ExifInterface;
import android.text.TextUtils;
import android.util.AttributeSet;
import android.util.Log;
import android.util.TypedValue;
import android.view.MotionEvent;
import android.view.ScaleGestureDetector;
import android.view.View;
import android.view.animation.AccelerateDecelerateInterpolator;

import java.io.IOException;

import javax.microedition.khronos.egl.EGL10;
import javax.microedition.khronos.egl.EGLConfig;
import javax.microedition.khronos.egl.EGLContext;
import javax.microedition.khronos.egl.EGLDisplay;

import game.monster.com.monstergame.R;

/**
 * @author yj
 * @remark study
 * @since 2018/8/24
 */
public class SeniorCropImageView_Stu extends android.support.v7.widget.AppCompatImageView implements ScaleGestureDetector.OnScaleGestureListener,
        View.OnLayoutChangeListener {

    /* For drawing color field start */

    /**
     * 线的颜色
     */
    private static final int LINE_COLOR = Color.WHITE;
    private static final int OUTER_MASK_COLOR = Color.argb(191, 0, 0, 0);


    private static final int LINE_WIDTH_IN_DP = 1;
    private final float[] mMatrixValues = new float[9];
    protected Matrix mSupportMatrix;
    protected ScaleGestureDetector mScaleGestureDetector;
    /* For drawing color field end */
    protected Paint mPaint;
    /*
     * 宽比高
     */
    protected float mRatio = 1.0f;
    protected RectF mCropRect;
    //RectFPadding是适应产品需求，给裁剪框mCropRect设置一下padding -- chenglin 2016年04月18日
    protected float RectFPadding = 0;
    protected int mLastX;
    protected int mLastY;
    protected OPERATION mOperation;
    private onBitmapLoadListener iBitmapLoading = null;
    private boolean mEnableDrawCropWidget = true;
    /*
    For scale and drag
     */
    private Matrix mBaseMatrix;
    private Matrix mDrawMatrix;
    private AccelerateDecelerateInterpolator sInterpolator = new AccelerateDecelerateInterpolator();
    private Path mPath;
    private int mLineWidth;
    private float mScaleMax = 3.0f;
    private RectF mBoundaryRect;
    private int mRotation = 0;
    private int mImageWidth;
    private int mImageHeight;
    private int mDisplayW;
    private int mDisplayH;

    public SeniorCropImageView_Stu(Context context) {
        this(context, null);
    }

    public SeniorCropImageView_Stu(Context context, AttributeSet attrs) {
        this(context, attrs, 0);
    }

    public SeniorCropImageView_Stu(Context context, AttributeSet attrs, int defStyleAttr) {
        super(context, attrs, defStyleAttr);

        if (attrs != null) {
            //应用并获取样式属性
            TypedArray a = context.obtainStyledAttributes(attrs, R.styleable.Life_CropImage);
            mRatio = a.getFloat(R.styleable.Life_CropImage_life_Crop_ratio, 1.0f);

            //回收 emm.....
            a.recycle();
        }

        init();
    }

    public static void decodeImageForCropping(final String path, final IDecodeCallback callback) {
        new Thread(new Runnable() {
            @Override
            public void run() {
                int rotation = 0;

                // 读取一下exif中的rotation
                try {
                    ExifInterface exif = new ExifInterface(path);
                    final int rotate = exif.getAttributeInt(ExifInterface.TAG_ORIENTATION, ExifInterface.ORIENTATION_UNDEFINED);
                    switch (rotate) {
                        case ExifInterface.ORIENTATION_ROTATE_90:
                            rotation = 90;
                            break;
                        case ExifInterface.ORIENTATION_ROTATE_180:
                            rotation = 180;
                            break;
                        case ExifInterface.ORIENTATION_ROTATE_270:
                            rotation = 270;
                            break;
                    }
                } catch (IOException e) {
                    e.printStackTrace();
                }

                final BitmapFactory.Options options = new BitmapFactory.Options();
                options.inJustDecodeBounds = true;
                BitmapFactory.decodeFile(path, options);

                final int textureLimit = getMaxTextureSize();

                int scale = 1;
                while (options.outWidth / scale >= textureLimit) {
                    scale *= 2;
                }

                while (options.outHeight / scale >= textureLimit) {
                    scale *= 2;
                }

                options.inSampleSize = scale;
                options.inJustDecodeBounds = false;

                Bitmap bitmap = null;
                try {
                    bitmap = BitmapFactory.decodeFile(path, options);
                } catch (OutOfMemoryError e) {
                    e.printStackTrace();
                }

                final Bitmap bimapDecoded = bitmap;
                if (bimapDecoded == null) {
                    return;
                }

                if (callback != null) {
                    callback.onDecoded(rotation, bimapDecoded);
                }
            }
        }).start();

    }

    private static int getMaxTextureSize() {
        EGL10 egl = (EGL10) EGLContext.getEGL();
        EGLDisplay display = egl.eglGetDisplay(EGL10.EGL_DEFAULT_DISPLAY);

        // Initialise
        int[] version = new int[2];
        egl.eglInitialize(display, version);

        // Query total number of configurations
        int[] totalConfigurations = new int[1];
        egl.eglGetConfigs(display, null, 0, totalConfigurations);

        // Query actual list configurations
        EGLConfig[] configurationsList = new EGLConfig[totalConfigurations[0]];
        egl.eglGetConfigs(display, configurationsList, totalConfigurations[0], totalConfigurations);

        int[] textureSize = new int[1];
        int maximumTextureSize = 0;

        // Iterate through all the configurations to located the maximum texture size
        for (int i = 0; i < totalConfigurations[0]; i++) {
            // Only need to check for width since opengl textures are always squared
            egl.eglGetConfigAttrib(display, configurationsList[i], EGL10.EGL_MAX_PBUFFER_WIDTH, textureSize);

            // Keep track of the maximum texture size
            if (maximumTextureSize < textureSize[0]) {
                maximumTextureSize = textureSize[0];
            }
        }

        // Release
        egl.eglTerminate(display);

        return maximumTextureSize;

    }

    @Override
    public void onLayoutChange(View v, int left, int top, int right, int bottom, int oldLeft, int oldTop, int oldRight, int oldBottom) {
        mDisplayW = right - left;
        mDisplayH = bottom - top;

        if (getDrawable() != null && ((BitmapDrawable) getDrawable()).getBitmap() != null) {
            calculateProperties(((BitmapDrawable) getDrawable()).getBitmap());
        }
    }

    private void init() {

        mScaleGestureDetector = new ScaleGestureDetector(getContext(), this);

        //matrix 矩阵
        mBaseMatrix = new Matrix();
        mDrawMatrix = new Matrix();
        mSupportMatrix = new Matrix();

        mLineWidth = (int) dipToPixels(LINE_WIDTH_IN_DP);//定义边框线的宽度
        mPaint = new Paint();

        // 表示第一个实线段长dashOnWidth，第一个虚线段长dashOffWidth
        mPath = new Path();

        mCropRect = new RectF();
        mBoundaryRect = new RectF();

        setScaleType(ScaleType.MATRIX);//设置缩放类型  -- 》 矩阵
        setClickable(true);
    }

    /**
     * 获取像素值
     * @param dip
     * @return
     */
    private float dipToPixels(float dip) {
        //return value * metrics.density;  dip * getResources().getDisplayMetrics().density
        return TypedValue.applyDimension(TypedValue.COMPLEX_UNIT_DIP, dip,
                getResources().getDisplayMetrics());
    }

    @Override
    protected void onAttachedToWindow() {
        super.onAttachedToWindow();

        addOnLayoutChangeListener(this);
    }

    @Override
    protected void onDetachedFromWindow() {
        super.onDetachedFromWindow();

        removeOnLayoutChangeListener(this);
    }

    /**
     * 设置图片的裁剪比例，比如3:4就是0.75
     *
     * @param ratio
     */
    public void setCropRatio(final float ratio) {
        if (mRatio == ratio) {
            return;
        }
        mRatio = ratio;

        //重新选择比例后，恢复旋转角度
        //setImageRotation(0);

        if (getDrawable() == null) {
            return;
        }

        calculateProperties(((BitmapDrawable) getDrawable()).getBitmap());

        postInvalidate();
    }

    public void setImageRotation(int rotation) {
        if (mRotation == rotation) {
            return;
        }

        mRotation = rotation;

        if (getDrawable() == null) {
            return;
        }

        calculateProperties(((BitmapDrawable) getDrawable()).getBitmap());

        postInvalidate();
    }

    public void setCropRectPadding(float padding) {
        RectFPadding = padding;
    }

    public void setImagePath(final String path) {
        if (TextUtils.isEmpty(path)) {
            return;
        }

        if (iBitmapLoading != null) {
            iBitmapLoading.onLoadPrepare();
        }
        decodeImageForCropping(path, new IDecodeCallback() {
            @Override
            public void onDecoded(final int rotation, final Bitmap bitmap) {
                post(new Runnable() {
                    @Override
                    public void run() {
                        mRotation = rotation;
                        setImageBitmap(bitmap);

                        if (iBitmapLoading != null) {
                            iBitmapLoading.onLoadFinish();
                        }
                    }
                });
            }
        });
    }

    @Override
    public void setImageBitmap(Bitmap bm) {
        calculateProperties(bm);
        super.setImageBitmap(bm);
    }

    public void setBitmapLoadingListener(onBitmapLoadListener iBitmapLoad) {
        iBitmapLoading = iBitmapLoad;
    }

    protected void calculateProperties(Bitmap bm) {
        mSupportMatrix.reset();
        mBaseMatrix.reset();

        int widthSize = mDisplayW;
        int heightSize = mDisplayH;

        generateCropRect(widthSize, heightSize);

        mImageWidth = bm.getWidth();
        mImageHeight = bm.getHeight();

        final boolean rotated = isImageRotated();

        final int bitmapWidth = rotated ? mImageHeight : mImageWidth;
        final int bitmapHeight = rotated ? mImageWidth : mImageHeight;

        mBoundaryRect.set(0, 0, bitmapWidth, bitmapHeight);

        final float widthScale = mCropRect.width() / bitmapWidth;
        final float heightScale = mCropRect.height() / bitmapHeight;

        final float scale = Math.max(widthScale, heightScale);
        final float scaledHeight = scale * bitmapHeight;
        final float scaledWidth = scale * bitmapWidth;

        // 移动到中心点
        final int translateX = (int) (mCropRect.left + mCropRect.width() / 2 - scaledWidth / 2);
        final int translateY = (int) (mCropRect.top + mCropRect.height() / 2 - scaledHeight / 2);

        mBaseMatrix.setScale(scale, scale);
        mBaseMatrix.postTranslate(translateX, translateY);

        mBaseMatrix.mapRect(mBoundaryRect);

        setImageMatrix(getDrawMatrix());
    }

    private boolean isImageRotated() {
        return ((mRotation % 360) == 90) || ((mRotation % 360) == 270);
    }

    private void generateCropRect(int boundaryWidth, int boundaryHeight) {
        //RectFPadding是适应产品需求，给裁剪框mCropRect设置一下padding -- chenglin 2016年04月18日
        boundaryWidth = boundaryWidth - (int) (RectFPadding * 2);
        boundaryHeight = boundaryHeight - (int) (RectFPadding * 2);

        int left;
        int top;
        int right;
        int bottom;

        boolean vertical;
        // 宽/高 大于比例的话，说明裁剪框是“竖直”的
        vertical = (float) boundaryWidth / boundaryHeight > mRatio;

        final int rectH = (int) (boundaryWidth / mRatio);
        final int rectW = (int) (boundaryHeight * mRatio);
        if (vertical) {
            left = (boundaryWidth - rectW) / 2;
            top = 0;
            right = (boundaryWidth + rectW) / 2;
            bottom = boundaryHeight;
        } else {
            left = 0;
            top = (boundaryHeight - rectH) / 2;
            right = boundaryWidth;
            bottom = (boundaryHeight + rectH) / 2;
        }

        //RectFPadding是适应产品需求，给裁剪框mCropRect设置一下padding -- chenglin 2016年04月18日
        mCropRect.set(left + RectFPadding, top + RectFPadding, right + RectFPadding, bottom + RectFPadding);
    }

    @Override
    protected void onDraw(Canvas canvas) {
        super.onDraw(canvas);

        if (!mEnableDrawCropWidget) {
            return;
        }

        if (getDrawable() == null) {
            return;
        }

        mPaint.reset();

        mPaint.setAntiAlias(true);
        mPaint.setColor(LINE_COLOR);
        mPaint.setStrokeWidth(mLineWidth);
        mPaint.setStyle(Paint.Style.STROKE);

        mPath.reset();

        // 上
        mPath.moveTo(mCropRect.left, mCropRect.top);
        mPath.lineTo(mCropRect.right, mCropRect.top);
        // 左
        mPath.moveTo(mCropRect.left, mCropRect.top);
        mPath.lineTo(mCropRect.left, mCropRect.bottom);
        // 右
        mPath.moveTo(mCropRect.right, mCropRect.top);
        mPath.lineTo(mCropRect.right, mCropRect.bottom);
        // 下
        mPath.moveTo(mCropRect.right, mCropRect.bottom);
        mPath.lineTo(mCropRect.left, mCropRect.bottom);

        canvas.drawPath(mPath, mPaint);

        // 绘制外部阴影部分
        mPaint.reset();
        mPaint.setAntiAlias(true);
        mPaint.setColor(Color.parseColor("#B3333333"));
        mPaint.setStyle(Paint.Style.FILL);

        //下面的四个矩形是装饰性的，就是裁剪框四周的四个阴影
        final int lineOffset = mLineWidth;
        if (mCropRect.top > 0) {
            canvas.drawRect(0, 0, getMeasuredWidth(), mCropRect.top - lineOffset, mPaint);
        }

        if (mCropRect.left > 0) {
            canvas.drawRect(mCropRect.top - lineOffset - RectFPadding, RectFPadding - lineOffset, mCropRect.left - lineOffset, mCropRect.bottom + lineOffset, mPaint);
        }

        if (mCropRect.right < getMeasuredWidth()) {
            canvas.drawRect(mCropRect.right + lineOffset, mCropRect.top - lineOffset, getMeasuredWidth(), mCropRect.bottom + lineOffset, mPaint);
        }

        if (mCropRect.bottom < getMeasuredHeight()) {
            canvas.drawRect(0, mCropRect.bottom + lineOffset, getMeasuredWidth(), getMeasuredHeight(), mPaint);
        }
    }

    public boolean onTouchEvent(MotionEvent ev) {

        if (ev.getPointerCount() > 1) {
            mOperation = OPERATION.SCALE;
            return mScaleGestureDetector.onTouchEvent(ev);
        }

        final int action = ev.getActionMasked();
        final int x = (int) ev.getX();
        final int y = (int) ev.getY();

        switch (action) {
            case MotionEvent.ACTION_DOWN:

                mOperation = OPERATION.DRAG;

                mLastX = x;
                mLastY = y;

                break;
            case MotionEvent.ACTION_MOVE:

                if (mOperation == OPERATION.DRAG) {
                    int deltaX = x - mLastX;
                    int deltaY = y - mLastY;

                    RectF boundary = getDrawBoundary(getDrawMatrix());

                    if (boundary.left + deltaX > mCropRect.left) {
                        deltaX = (int) (mCropRect.left - boundary.left);
                    } else if (boundary.right + deltaX < mCropRect.right) {
                        deltaX = (int) (mCropRect.right - boundary.right);
                    }

                    if (boundary.top + deltaY > mCropRect.top) {
                        deltaY = (int) (mCropRect.top - boundary.top);
                    } else if (boundary.bottom + deltaY < mCropRect.bottom) {
                        deltaY = (int) (mCropRect.bottom - boundary.bottom);
                    }

                    mSupportMatrix.postTranslate(deltaX, deltaY);

                    setImageMatrix(getDrawMatrix());

                    mLastX = x;
                    mLastY = y;
                }
                break;
            case MotionEvent.ACTION_CANCEL:
            case MotionEvent.ACTION_POINTER_UP:
            case MotionEvent.ACTION_UP:
                mLastX = 0;
                mLastY = 0;
                mOperation = null;
                break;
        }

        return super.onTouchEvent(ev);
    }

    public Bitmap getOriginBitmap() {
        BitmapDrawable drawable = (BitmapDrawable) getDrawable();
        return drawable == null ? null : drawable.getBitmap();
    }

    /**
     * 保存图片为bitmap
     */
    public Bitmap saveCrop() throws OutOfMemoryError {
        if (getDrawable() == null) {
            return null;
        }

        Bitmap origin = getOriginBitmap();
        Matrix drawMatrix = getDrawMatrix();

        // 反转一下矩阵
        Matrix inverse = new Matrix();
        drawMatrix.invert(inverse);

        // 把裁剪框对应到原图上去
        RectF cropMapped = new RectF();
        inverse.mapRect(cropMapped, mCropRect);

        clampCropRect(cropMapped, origin.getWidth(), origin.getHeight());

        // 如果产生了旋转，需要一个旋转矩阵
        Matrix rotationM = new Matrix();
        if (mRotation % 360 != 0) {
            rotationM.postRotate(mRotation, origin.getWidth() / 2, origin.getHeight() / 2);
        }

        Bitmap cropped = Bitmap.createBitmap(
                origin, (int) cropMapped.left, (int) cropMapped.top, (int) cropMapped.width(), (int) cropMapped.height(), rotationM, true
        );


        return cropped;
    }

    private void clampCropRect(RectF cropRect, int borderW, int borderH) {
        if (cropRect.left < 0) {
            cropRect.left = 0;
        }

        if (cropRect.top < 0) {
            cropRect.top = 0;
        }

        if (cropRect.right > borderW) {
            cropRect.right = borderW;
        }

        if (cropRect.bottom > borderH) {
            cropRect.bottom = borderH;
        }
    }

    @Override
    public boolean onScale(ScaleGestureDetector detector) {
        float scale = detector.getScaleFactor();

        if (scale == 1.0f) {
            return true;
        }

        final float currentScale = getScale(mSupportMatrix);

        final float centerX = detector.getFocusX();
        final float centerY = detector.getFocusY();

        if ((currentScale <= 1.0f && scale < 1.0f)
                || (currentScale >= mScaleMax && scale > 1.0f)) {
            return true;
        }

        if (currentScale * scale < 1.0f) {
            scale = 1.0f / currentScale;
        } else if (currentScale * scale > mScaleMax) {
            scale = mScaleMax / currentScale;
        }

        mSupportMatrix.postScale(scale, scale, centerX, centerY);

        RectF boundary = getDrawBoundary(getDrawMatrix());

        float translateX = 0;
        if (boundary.left > mCropRect.left) {
            translateX = mCropRect.left - boundary.left;
        } else if (boundary.right < mCropRect.right) {
            translateX = mCropRect.right - boundary.right;
        }

        Log.d("scale", "x==>" + translateX);

        float translateY = 0;
        if (boundary.top > mCropRect.top) {
            translateY = mCropRect.top - boundary.top;
        } else if (boundary.bottom < mCropRect.bottom) {
            translateY = mCropRect.bottom - boundary.bottom;
        }

        mSupportMatrix.postTranslate(translateX, translateY);

        setImageMatrix(getDrawMatrix());

        return true;
    }

    protected Matrix getDrawMatrix() {
        mDrawMatrix.reset();

        if (mRotation % 360 != 0) {
            final boolean rotated = isImageRotated();

            final int width = rotated ? mImageHeight : mImageWidth;
            final int height = rotated ? mImageWidth : mImageHeight;

            mDrawMatrix.postRotate(mRotation, mImageWidth / 2, mImageHeight / 2);

            if (rotated) {
                final int translateX = (width - mImageWidth) / 2;
                final int translateY = (height - mImageHeight) / 2;

                mDrawMatrix.postTranslate(translateX, translateY);
            }
        }

        mDrawMatrix.postConcat(mBaseMatrix);

        mDrawMatrix.postConcat(mSupportMatrix);

        return mDrawMatrix;
    }

    @Override
    public boolean onScaleBegin(ScaleGestureDetector detector) {
        return true;
    }

    @Override
    public void onScaleEnd(ScaleGestureDetector detector) {
        final float currentScale = getScale(mSupportMatrix);
        if (currentScale < 1.0f) {
            Log.e("onScaleEnd", "currentScale==>" + currentScale);

            RectF boundary = getDrawBoundary(getDrawMatrix());
            post(new AnimatedZoomRunnable(currentScale, 1.0f, boundary.centerX(), boundary.centerY()));
        }
    }

    protected RectF getDrawBoundary(Matrix matrix) {
        Drawable drawable = getDrawable();
        if (drawable == null) {
            return mBoundaryRect;
        }

        final int bitmapWidth = drawable.getIntrinsicWidth();
        final int bitmapHeight = drawable.getIntrinsicHeight();

        mBoundaryRect.set(0, 0, bitmapWidth, bitmapHeight);

        matrix.mapRect(mBoundaryRect);

        return mBoundaryRect;
    }

    public float getScale(Matrix matrix) {
        return (float) Math.sqrt((float) Math.pow(getValue(matrix, Matrix.MSCALE_X), 2) + (float) Math.pow(getValue(matrix, Matrix.MSKEW_Y), 2));
    }

    /**
     * Helper method that 'unpacks' a Matrix and returns the required value
     *
     * @param matrix     - Matrix to unpack
     * @param whichValue - Which value from Matrix.M* to return
     * @return float - returned value
     */
    private float getValue(Matrix matrix, int whichValue) {
        matrix.getValues(mMatrixValues);
        return mMatrixValues[whichValue];
    }

    public void enableDrawCropWidget(boolean enable) {
        mEnableDrawCropWidget = enable;
    }

    protected enum OPERATION {
        DRAG, SCALE
    }

    public enum Type {
        CENTER_CROP, CENTER_INSIDE
    }

    public interface IDecodeCallback {
        void onDecoded(final int rotation, final Bitmap bitmap);
    }

    //setImagePath这个方法耗时，需要显示进度条，这个是监听
    public interface onBitmapLoadListener {
        void onLoadPrepare();

        void onLoadFinish();
    }

    private class AnimatedZoomRunnable implements Runnable {

        private final float mFocalX, mFocalY;
        private final long mStartTime;
        private final float mZoomStart, mZoomEnd;

        public AnimatedZoomRunnable(final float currentZoom, final float targetZoom,
                                    final float focalX, final float focalY) {
            mFocalX = focalX;
            mFocalY = focalY;
            mStartTime = System.currentTimeMillis();
            mZoomStart = currentZoom;
            mZoomEnd = targetZoom;
        }

        @Override
        public void run() {

            float t = interpolate();
            float scale = mZoomStart + t * (mZoomEnd - mZoomStart);
            float deltaScale = scale / getScale(mSupportMatrix);

            mSupportMatrix.postScale(deltaScale, deltaScale, mFocalX, mFocalY);
            setImageMatrix(getDrawMatrix());

            // We haven't hit our target scale yet, so post ourselves again
            if (t < 1f) {
                postOnAnimation(this);
            }
        }

        private float interpolate() {
            float t = 1f * (System.currentTimeMillis() - mStartTime) / 200;
            t = Math.min(1f, t);
            t = sInterpolator.getInterpolation(t);
            return t;
        }
    }

}
