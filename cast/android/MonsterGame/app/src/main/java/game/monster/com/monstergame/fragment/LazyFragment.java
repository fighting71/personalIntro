package game.monster.com.monstergame.fragment;

import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import game.monster.com.monstergame.cusInterface.IGetFunction;
import game.monster.com.monstergame.cusInterface.ISetFunction;

/**
 * @author yj
 * @remark
 * @since 2018/8/20
 */

public abstract class LazyFragment extends Fragment {

    protected View rootView;

    protected IGetFunction<Boolean> hasLoding;

    /**
     * rootView是否初始化标志，防止回调函数在rootView为空的时候触发
     */
    private boolean hasCreateView;

    /**
     * 当前Fragment是否处于可见状态标志，防止因ViewPager的缓存机制而导致回调函数的触发
     */
    private boolean isFragmentVisible;

    @Override
    public void setUserVisibleHint(boolean isVisibleToUser) {
        super.setUserVisibleHint(isVisibleToUser);
        Log.d(getTag(), "setUserVisibleHint() -> isVisibleToUser: " + isVisibleToUser);
        if (rootView == null) {
            return;
        }
        hasCreateView = true;
        if (isVisibleToUser) {
            onFragmentVisibleChange(true);
            isFragmentVisible = true;
            return;
        }
        if (isFragmentVisible) {
            onFragmentVisibleChange(false);
            isFragmentVisible = false;
        }
    }

    /**************************************************************
     *  自定义的回调方法，子类可根据需求重写
     *************************************************************/

    /**
     * 当前fragment可见状态发生变化时会回调该方法
     * 如果当前fragment是第一次加载，等待onCreateView后才会回调该方法，其它情况回调时机跟 {@link #setUserVisibleHint(boolean)}一致
     * 在该回调方法中你可以做一些加载数据操作，甚至是控件的操作，因为配合fragment的view复用机制，你不用担心在对控件操作中会报 null 异常
     *
     * @param isVisible true  不可见 -> 可见
     *                  false 可见  -> 不可见
     */
    protected void onFragmentVisibleChange(boolean isVisible) {
        Log.w(getTag(), "onFragmentVisibleChange -> isVisible: " + isVisible);
        if (isVisible && rootView != null
                && (hasLoding == null || !hasLoding.run())) {
            loadData();
            Log.w(getTag(), "初次进行加载数据");
        }
    }

    protected abstract void loadData();


}
