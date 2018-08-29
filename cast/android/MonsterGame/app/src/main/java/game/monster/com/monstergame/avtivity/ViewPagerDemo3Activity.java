package game.monster.com.monstergame.avtivity;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentStatePagerAdapter;
import android.support.v4.view.PagerTabStrip;
import android.support.v4.view.ViewPager;
import android.support.v7.app.AppCompatActivity;

import java.util.ArrayList;
import java.util.List;

import butterknife.BindView;
import butterknife.ButterKnife;
import game.monster.com.monstergame.R;
import game.monster.com.monstergame.adapter.viewPager.SimpleAdapter;
import game.monster.com.monstergame.fragment.GreenFragment;
import game.monster.com.monstergame.fragment.RedFragment;

public class ViewPagerDemo3Activity extends AppCompatActivity {

    @BindView(R.id.pager_tab)
    PagerTabStrip pagerTab;
    @BindView(R.id.vp_container)
    ViewPager vpContainer;
    private List<Fragment> fragmentList;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_view_page_demo3);
        ButterKnife.bind(this);

        init();

    }

    private void init() {

        fragmentList = new ArrayList<>();

        fragmentList.add(new RedFragment());
        fragmentList.add(new GreenFragment());

        //与Fragment结合使用其实也一样，只是用Fragment代替原先的View，填充Viewpager；然后就是Adapter不一样，配合Fragment使用的有两个Adapter：FragmentPagerAdapter和FragmentStatePagerAdapter。

//        相同点：
//        FragmentPagerAdapter和FragmentStatePagerAdapter都继承自PagerAdapter
//
//        不同点：
//        卸载不再需fragment时，各自采用的处理方法有所不同
//
//        FragmentStatePagerAdapter会销毁不需要的fragment。事务提交后， activity的FragmentManager中的fragment会被彻底移除。 FragmentStatePagerAdapter类名中的“state”表明：在销毁fragment时，可在onSaveInstanceState(Bundle)方法中保存fragment的Bundle信息。用户切换回来时，保存的实例状态可用来恢复生成新的fragment
//
//        FragmentPagerAdapter有不同的做法。对于不再需要的fragment， FragmentPagerAdapter会选择调用事务的detach(Fragment)方法来处理它，而非remove(Fragment)方法。也就是说， FragmentPagerAdapter只是销毁了fragment的视图， fragment实例还保留在FragmentManager中。因此，FragmentPagerAdapter创建的fragment永远不会被销毁
//
//        也就是：在destroyItem()方法中，FragmentStatePagerAdapter调用的是remove()方法，适用于页面较多的情况；FragmentPagerAdapter调用的是detach()方法，适用于页面较少的情况。但是有页面数据需要刷新的情况，不管是页面少还是多，还是要用FragmentStatePagerAdapter，否则页面会因为没有重建得不到刷新

//        vpContainer.setAdapter(new SimpleAdapter(getSupportFragmentManager(),this,fragmentList));

        vpContainer.setAdapter(new FragmentStatePagerAdapter(getSupportFragmentManager()) {
            @Override
            public Fragment getItem(int position) {
                return fragmentList.get(position);
            }

            @Override
            public int getCount() {
                return fragmentList.size();
            }
        });

    }
}
