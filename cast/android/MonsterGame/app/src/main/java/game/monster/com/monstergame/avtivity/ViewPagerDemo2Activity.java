package game.monster.com.monstergame.avtivity;

import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.view.PagerAdapter;
import android.support.v4.view.ViewPager;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

import butterknife.BindView;
import butterknife.ButterKnife;
import game.monster.com.monstergame.R;
import game.monster.com.monstergame.adapter.viewPager.SimpleAdapter;
import game.monster.com.monstergame.adapter.viewPager.transformer.DepthPageTransformer;


/**
 *
 */
public class ViewPagerDemo2Activity extends AppCompatActivity {

    @BindView(R.id.vp_container)
    ViewPager vpContainer;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_view_page_demo2);
        ButterKnife.bind(this);

        init();

        initView();

    }

    List<Fragment> fragmentList;

    private void initView() {

        // 初始测试 S
        List<DataBean> list = new ArrayList<>();
        list.add(new DataBean("标题一","emm... 吃饭、睡觉、打豆豆"));
        list.add(new DataBean("标题二","doo... I have nothing to do"));
        list.add(new DataBean("标题三","na...  I've reading books of old"));
        vpContainer.setAdapter(new MyPagerAdapter(this,list));
        // 初始测试 E

        //设置翻页特效
        //开源框架ViewPagerTransforms :  https://github.com/ToxicBakery/ViewPagerTransforms
        vpContainer.setPageTransformer(false,new DepthPageTransformer());

//        <翻页监听>
//        1. 设置方法
//        addOnPageChangeListener()
//        2. 翻页监听接口
//        ViewPager.OnPageChangeListener

//        3. 重写方法
//        onPageScrolled(int position, float positionOffset, int positionOffsetPixels)
//
//        页面滑动状态停止前一直调用
//
//        position：当前点击滑动页面的位置
//        positionOffset：当前页面偏移的百分比
//        positionOffsetPixels：当前页面偏移的像素位置
//
//        onPageSelected(int position)
//
//        滑动后显示的页面和滑动前不同，调用
//
//        position：选中显示页面的位置
//
//        onPageScrollStateChanged(int state)
//
//        页面状态改变时调用
//
//        state：当前页面的状态
//
//        SCROLL_STATE_IDLE：空闲状态
//        SCROLL_STATE_DRAGGING：滑动状态
//        SCROLL_STATE_SETTLING：滑动后滑翔的状态

        vpContainer.addOnPageChangeListener(new ViewPager.OnPageChangeListener() {
            @Override
            public void onPageScrolled(int position, float positionOffset, int positionOffsetPixels) {
                Log.e("vp","滑动中=====position:"+ position + "   positionOffset:"+ positionOffset + "   positionOffsetPixels:"+positionOffsetPixels);
            }

            @Override
            public void onPageSelected(int position) {
                Log.e("vp","显示页改变=====postion:"+ position);
            }

            @Override
            public void onPageScrollStateChanged(int state) {
                switch (state) {
                    case ViewPager.SCROLL_STATE_IDLE:
                        Log.e("vp","状态改变=====SCROLL_STATE_IDLE====静止状态");
                        break;
                    case ViewPager.SCROLL_STATE_DRAGGING:
                        Log.e("vp","状态改变=====SCROLL_STATE_DRAGGING==滑动状态");
                        break;
                    case ViewPager.SCROLL_STATE_SETTLING:
                        Log.e("vp","状态改变=====SCROLL_STATE_SETTLING==滑翔状态");
                        break;
                }
            }
        });

    }

    public class DataBean{

        private String title;

        private String content;

        public String getTitle() {
            return title;
        }

        public void setTitle(String title) {
            this.title = title;
        }

        public String getContent() {
            return content;
        }

        public void setContent(String content) {
            this.content = content;
        }

        public DataBean(String title, String content) {
            this.title = title;
            this.content = content;
        }
    }

    public class MyPagerAdapter extends PagerAdapter {
        private Context mContext;
        private List<DataBean> mData;

        public MyPagerAdapter(Context context ,List<DataBean> list) {
            mContext = context;
            mData = list;
        }

        @Override
        public int getCount() {
            return mData.size();
        }

        @Override
        public Object instantiateItem(ViewGroup container, int position) {
            View view = View.inflate(mContext, R.layout.item_tv,null);
            TextView tv = (TextView) view.findViewById(R.id.tv_item);
            tv.setText(mData.get(position).getContent());
            container.addView(view);
            return view;
        }

        @Override
        public void destroyItem(ViewGroup container, int position, Object object) {
            // super.destroyItem(container,position,object); 这一句要删除，否则报错
            container.removeView((View)object);
        }

        //获取标题栏
        @Override
        public CharSequence getPageTitle(int position) {
            return mData.get(position).getTitle();
        }

        @Override
        public boolean isViewFromObject(View view, Object object) {
            return view == object;
        }
    }

    protected void init() {

    }

}
