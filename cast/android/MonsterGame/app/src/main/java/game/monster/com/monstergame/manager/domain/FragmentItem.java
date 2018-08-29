package game.monster.com.monstergame.manager.domain;

import android.support.v4.app.Fragment;

/**
 * @author yj
 * @remark
 * @since 2018/8/20
 */

public class FragmentItem {

    private String title;

    private Fragment fragment;

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public Fragment getFragment() {
        return fragment;
    }

    public void setFragment(Fragment fragment) {
        this.fragment = fragment;
    }

    public FragmentItem(String title, Fragment fragment) {
        this.title = title;
        this.fragment = fragment;
    }
}
