package game.monster.com.monstergame.avtivity;

import android.Manifest;
import android.annotation.TargetApi;
import android.content.ContentUris;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.provider.DocumentsContract;
import android.provider.MediaStore;
import android.support.annotation.NonNull;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.OnClick;
import game.monster.com.monstergame.R;
import game.monster.com.monstergame.cusConst.IntentRequestCode;
import game.monster.com.monstergame.extension.view.SeniorCropImageView;

public class CutPictureActivity extends AppCompatActivity {

    @BindView(R.id.toolbar)
    Toolbar toolbar;
    @BindView(R.id.btn_sel_picture)
    Button btnSelPicture;
    @BindView(R.id.fab)
    FloatingActionButton fab;
    @BindView(R.id.sciv_picture)
    SeniorCropImageView scivPicture;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cut_picture);
        ButterKnife.bind(this);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                        .setAction("Action", null).show();
            }
        });

        //设置裁剪比例
        scivPicture.setCropRatio(23f / 40f);

        //设置裁剪框的padding
//        scivPicture.setCropRectPadding(20f, 20f, 0f, 0f);

        //让这个裁剪框显示图片
//        scivPicture.setImagePath(path);

        //setImagePath这个方法比较耗时，需要显示进度条，这个是监听：
//        scivPicture.setBitmapLoadingListener(new SeniorCropImageView.onBitmapLoadListener() {
//            @Override
//            public void onLoadPrepare() {
//                showProgress();
//            }
//
//            @Override
//            public void onLoadFinish() {
//                hideProgress();
//            }
//
//        });


    }

    private void openAlbum() {
        Intent intent = new Intent("android.intent.action.GET_CONTENT");
        intent.setType("image/*");
        startActivityForResult(intent, IntentRequestCode.OPEN_PICTURE);//打开系统相册

    }

    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {
        switch (requestCode) {
            case 1:
                if (grantResults.length > 0 && grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                    openAlbum();
                } else {
                    Toast.makeText(this, "You denied the permission", Toast.LENGTH_SHORT).show();
                }
                break;
            default:
        }
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (requestCode == IntentRequestCode.OPEN_PICTURE && resultCode == RESULT_OK && null != data) {
            if (Build.VERSION.SDK_INT >= 19) {
                handleImageOnKitkat(data);
            } else {
                handleImageBeforeKitkat(data);
            }
        }
    }

    @TargetApi(19)
    private void handleImageOnKitkat(Intent data) {
        String imagePath = null;
        Uri uri = data.getData();
        if (DocumentsContract.isDocumentUri(this, uri)) {
            //如果是document类型的uri，则通过document id处理
            String docId = DocumentsContract.getDocumentId(uri);
            if ("com.android.providers.media.documents".equals(uri.getAuthority())) {
                String id = docId.split(":")[1];
                String selection = MediaStore.Images.Media._ID + "=" + id;
                imagePath = getImagePath(MediaStore.Images.Media.EXTERNAL_CONTENT_URI, selection);
            } else if ("com.android.providers.downloads.documents".equals(uri.getAuthority())) {
                Uri contentUri = ContentUris.withAppendedId(Uri.parse("content:" +
                        "//downloads/public_downloads"), Long.valueOf(docId));
                imagePath = getImagePath(contentUri, null);
            }
        } else if ("content".equalsIgnoreCase(uri.getScheme())) {
            //如果是content类型的uri，则使用普通方式处理
            imagePath = getImagePath(uri, null);
        } else if ("file".equalsIgnoreCase(uri.getScheme())) {
            //如果是File类型的uri，直接获取图片路径即可
            imagePath = uri.getPath();
        }
        displayImage(imagePath);//根据图片路径显示图片

    }

    private void handleImageBeforeKitkat(Intent data) {
        Uri uri = data.getData();
        String imagePath = getImagePath(uri, null);
        displayImage(imagePath);

    }

    private String getImagePath(Uri uri, String selection) {
        String path = null;
        //通过uri和selection来获取真实的图片路径
        Cursor cursor = getContentResolver().query(uri, null, selection, null, null);
        if (cursor != null) {
            if (cursor.moveToFirst()) {
                path = cursor.getString(cursor.getColumnIndex(MediaStore.Images.Media.DATA));
            }
            cursor.close();
        }
        return path;
    }

    private void displayImage(String imagePath) {
        if (imagePath != null) {
            Bitmap bitmap = BitmapFactory.decodeFile(imagePath);
            scivPicture.setImageBitmap(bitmap);
        } else {
            Toast.makeText(this, "failed to get image", Toast.LENGTH_SHORT).show();
        }
    }

    @OnClick({R.id.btn_sel_picture, R.id.btn_save})
    public void onViewClicked(View view) {

        switch (view.getId()) {
            case R.id.btn_sel_picture:

                if (ContextCompat.checkSelfPermission(CutPictureActivity.this,
                        Manifest.permission.WRITE_EXTERNAL_STORAGE) != PackageManager.PERMISSION_GRANTED) {
                    ActivityCompat.requestPermissions(CutPictureActivity.this, new
                            String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE}, 1);
                } else {
                    //打开系统相册
                    openAlbum();
                }

                break;

            case R.id.btn_save:

                Bitmap imageViewBitmap = null;
                try {
                    imageViewBitmap = scivPicture.saveCrop();
                    if (imageViewBitmap == null) {
                        return;
                    }
                    scivPicture.setImageBitmap(imageViewBitmap);
                } catch (OutOfMemoryError e) {
                    imageViewBitmap = scivPicture.getOriginBitmap();
                    scivPicture.setImageBitmap(imageViewBitmap);
                    Toast.makeText(this, e.toString(), Toast.LENGTH_LONG).show();
                }


                break;

        }

    }
}
