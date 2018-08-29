package game.monster.com.monstergame.avtivity;

import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v4.app.Fragment;
import android.support.v4.view.ViewPager;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.LinearLayout;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

import butterknife.BindView;
import butterknife.ButterKnife;
import game.monster.com.monstergame.R;
import game.monster.com.monstergame.fragment.CatalogFragment;
import game.monster.com.monstergame.fragment.GreenFragment;
import game.monster.com.monstergame.fragment.News2Fragment;
import game.monster.com.monstergame.fragment.NewsFragment;
import game.monster.com.monstergame.fragment.RedFragment;
import game.monster.com.monstergame.manager.ViewPagerManager;
import game.monster.com.monstergame.manager.domain.FragmentItem;

public class ViewPagerDemo4Activity extends AppCompatActivity {

    @BindView(R.id.toolbar)
    Toolbar toolbar;
    @BindView(R.id.vp_container)
    ViewPager vpContainer;
    @BindView(R.id.fab)
    FloatingActionButton fab;
    @BindView(R.id.ll_tap_container)
    LinearLayout llTapContainer;
    private LayoutInflater layoutInflater;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_view_pager_demo4);
        ButterKnife.bind(this);
        setSupportActionBar(toolbar);

        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                        .setAction("Action", null).show();
            }
        });

        init();

        initView();

        bindEvent();

    }

    private void bindEvent() {

        List<FragmentItem> list = fragmentList.stream().map(u -> new FragmentItem("标题", u)).collect(Collectors.toList());

        ViewPagerManager viewPagerManager = new ViewPagerManager(this, this, vpContainer, list, llTapContainer, u -> {
            u.setPadding(60, 40, 60, 40);
        }).init();

//        for (int i = 0; i < titleList.size(); i++) {
//
//            int showIndex = i;
//
//            TextView view = (TextView) layoutInflater.inflate(R.layout.item_tv, null);
//            view.setText(titleList.get(i));
//            view.setPadding(60, 40, 60, 40);
//            view.setOnClickListener(v -> changeShowPag(showIndex));
//
//            if (i == 0) {
//                view.setBackgroundResource(R.drawable.bottom_border);
//            }
//
//            llTapContainer.addView(view);
//
//        }

//        vpContainer.setPageTransformer(false,new DepthPageTransformer());

//        vpContainer.addOnPageChangeListener(new ViewPager.OnPageChangeListener() {
//            @Override
//            public void onPageScrolled(int position, float positionOffset, int positionOffsetPixels) {
//
//            }
//
//            @Override
//            public void onPageSelected(int position) {
//
//                changeTabStyle(position);
//
//            }
//
//            @Override
//            public void onPageScrollStateChanged(int state) {
//
//            }
//        });

    }

//    protected void changeTabStyle(int index) {
//        for (int i = 0; i < llTapContainer.getChildCount(); i++) {
//            View view = llTapContainer.getChildAt(i);
//            if (i == index) {
//                view.setBackgroundResource(R.drawable.bottom_border);
//            } else {
//                view.setBackgroundResource(R.color.colorWhite);
//            }
//        }
//    }
//
//    protected void changeShowPag(int index) {
//
//        if (index < fragmentList.size()) {
//            vpContainer.setCurrentItem(index);
//            changeTabStyle(index);
//        }
//
//    }

    private void initView() {

//        vpContainer.setAdapter(new SimpleAdapter(getSupportFragmentManager(), this, fragmentList, titleList));

    }

    private List<Fragment> fragmentList;

    private List<String> titleList;

    private void init() {

        layoutInflater = this.getLayoutInflater();

        fragmentList = new ArrayList<>();
        fragmentList.add(new NewsFragment());
        fragmentList.add(new News2Fragment());
        fragmentList.add(new CatalogFragment());
        fragmentList.add(new GreenFragment());
        fragmentList.add(new RedFragment());

//        titleList = new ArrayList<>();
//        titleList.add("消息");
//        titleList.add("类目");
//        titleList.add("绿色");
//        titleList.add("红色");

    }


}
