package game.monster.com.monstergame.avtivity;

import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.view.PagerAdapter;
import android.support.v4.view.ViewPager;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.RelativeLayout;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

import butterknife.BindView;
import butterknife.ButterKnife;
import game.monster.com.monstergame.R;
import game.monster.com.monstergame.adapter.viewPager.SimpleAdapter;
import game.monster.com.monstergame.fragment.GreenFragment;
import game.monster.com.monstergame.fragment.RedFragment;


/**
 *
 */
public class ViewPagerDemoActivity extends AppCompatActivity {

    @BindView(R.id.vp_container)
    ViewPager vpContainer;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_view_page_demo);
        ButterKnife.bind(this);

        init();

        initView();

    }

    private void initView() {

        // 初始测试 S
        List<String> list = new ArrayList<>();
        list.add("--=");
        list.add("two");
        list.add("three");
        vpContainer.setAdapter(new MyPagerAdapter(this,list));
        // 初始测试 E

    }

    public class MyPagerAdapter extends PagerAdapter {
        private Context mContext;
        private List<String> mData;

        public MyPagerAdapter(Context context ,List<String> list) {
            mContext = context;
            mData = list;
        }

        @Override
        public int getCount() {
            return mData.size();
        }

        @Override
        public Object instantiateItem(ViewGroup container, int position) {
            View view = View.inflate(mContext, R.layout.item_btn,null);
            TextView tv = (TextView) view.findViewById(R.id.btn_item);
            tv.setText(mData.get(position));
            container.addView(view);
            return view;
        }

        @Override
        public void destroyItem(ViewGroup container, int position, Object object) {
            // super.destroyItem(container,position,object); 这一句要删除，否则报错
            container.removeView((View)object);
        }

        @Override
        public boolean isViewFromObject(View view, Object object) {
            return view == object;
        }
    }

    protected void init() {

    }

}
