package game.monster.com.monstergame.adapter.viewPager;

import android.content.Context;
import android.support.annotation.NonNull;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;
import android.view.View;

import java.util.List;

/**
 * @author yj
 * @remark
 * @since 2018/8/15
 */

public class SimpleAdapter extends FragmentPagerAdapter {

    private Context context;
    private List<Fragment> fragmentList;
    private List<String> titleList;

    public SimpleAdapter(FragmentManager fm, @NonNull Context context, @NonNull List<Fragment> fragmentList) {
        super(fm);
        this.context = context;
        this.fragmentList = fragmentList;
    }

    public SimpleAdapter(FragmentManager fm, @NonNull Context context, @NonNull List<Fragment> fragmentList, @NonNull List<String> titleList) {
        this(fm, context, fragmentList);
        this.titleList = titleList;
    }


    //获取标题栏
    @Override
    public CharSequence getPageTitle(int position) {
        if (titleList != null && titleList.size() > position) {
            return titleList.get(position);
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
    public android.support.v4.app.Fragment getItem(int position) {
        return fragmentList.get(position);
    }

}
