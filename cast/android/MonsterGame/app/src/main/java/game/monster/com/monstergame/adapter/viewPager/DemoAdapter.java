package game.monster.com.monstergame.adapter.viewPager;

import android.content.Context;
import android.support.annotation.NonNull;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;

import java.util.List;

import game.monster.com.monstergame.manager.domain.FragmentItem;

/**
 * @author yj
 * @remark
 * @since 2018/8/15
 */

public class DemoAdapter extends FragmentPagerAdapter {

    private Context context;
    private List<FragmentItem> fragmentList;

    public DemoAdapter(FragmentManager fm, @NonNull Context context, @NonNull List<FragmentItem> fragmentList) {
        super(fm);
        this.context = context;
        this.fragmentList = fragmentList;
    }

    public DemoAdapter(FragmentManager fm, @NonNull Context context, @NonNull List<FragmentItem> fragmentList, @NonNull List<String> titleList) {
        this(fm, context, fragmentList);
    }


    //获取标题栏
    @Override
    public CharSequence getPageTitle(int position) {
        if (fragmentList.size() > position) {
            return fragmentList.get(position).getTitle();
        } else {
            return super.getPageTitle(position);
        }
    }

    @Override
    public int getCount() {
        return fragmentList.size();
    }

//    @Override
//    public boolean isViewFromObject(View view, Object object) {
//        return view == object;
//    }

    @Override
    public Fragment getItem(int position) {
        return fragmentList.get(position).getFragment();
    }

}
