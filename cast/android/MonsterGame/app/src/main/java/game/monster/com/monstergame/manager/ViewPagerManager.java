package game.monster.com.monstergame.manager;

import android.content.Context;
import android.support.annotation.NonNull;
import android.support.v4.app.FragmentActivity;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import org.w3c.dom.Text;

import java.util.List;

import game.monster.com.monstergame.R;
import game.monster.com.monstergame.adapter.viewPager.DemoAdapter;
import game.monster.com.monstergame.adapter.viewPager.transformer.DepthPageTransformer;
import game.monster.com.monstergame.cusInterface.ISetFunction;
import game.monster.com.monstergame.manager.domain.FragmentItem;

/**
 * @author yj
 * @remark
 * @since 2018/8/20
 */

public class ViewPagerManager {

    private Context context;

    private FragmentActivity parentActivity;
    private ViewPager viewPager;

    private List<FragmentItem> fragmentItemList;
    private LayoutInflater layoutInflater;
    private ViewGroup viewGroup;

    /**
     * @param context
     * @param parentActivity
     * @param viewPager
     * @param fragmentItemList
     */
    public ViewPagerManager(@NonNull Context context, @NonNull FragmentActivity parentActivity, @NonNull ViewPager viewPager, @NonNull List<FragmentItem> fragmentItemList) {
        this.context = context;
        this.parentActivity = parentActivity;
        this.viewPager = viewPager;
        this.fragmentItemList = fragmentItemList;
    }

    public ViewPagerManager(@NonNull Context context, @NonNull FragmentActivity parentActivity, @NonNull ViewPager viewPager,
                            @NonNull List<FragmentItem> fragmentItemList, ViewGroup viewGroup, ISetFunction<TextView> setStyle) {
        this(context, parentActivity, viewPager, fragmentItemList);
        this.viewGroup = viewGroup;
        layoutInflater = parentActivity.getLayoutInflater();
        initTapGroup(viewGroup, fragmentItemList, setStyle, index -> changeShowPag(index));

    }

    /**
     * @param viewGroup
     * @param fragmentItems
     * @param setStyle      tapItem 样式设置
     * @param clickEvent    tapItem 点击事件
     */
    protected void initTapGroup(ViewGroup viewGroup, List<FragmentItem> fragmentItems, ISetFunction<TextView> setStyle, ISetFunction<Integer> clickEvent) {
        for (int i = 0; i < fragmentItems.size(); i++) {

            int showIndex = i;

            TextView view = (TextView) layoutInflater.inflate(R.layout.item_tv, null);

            view.setText(fragmentItems.get(i).getTitle());
            setStyle.run(view);
            view.setOnClickListener(v -> clickEvent.run(showIndex));

            if (i == 0) {
                view.setBackgroundResource(R.drawable.bottom_border);
            }

            viewGroup.addView(view);

        }
    }

    protected void pageScrolled(int position, float positionOffset, int positionOffsetPixels) {

    }

    protected void pageSelected(int position) {

    }

    public void pageScrollStateChanged(int state) {

    }

    /**
     * 初始化
     */
    public ViewPagerManager init() {

        viewPager.setAdapter(new DemoAdapter(parentActivity.getSupportFragmentManager(), context, fragmentItemList));

        viewPager.setPageTransformer(false, new DepthPageTransformer());

        viewPager.addOnPageChangeListener(new ViewPager.OnPageChangeListener() {
            @Override
            public void onPageScrolled(int position, float positionOffset, int positionOffsetPixels) {
                pageScrolled(position, positionOffset, positionOffsetPixels);
            }

            @Override
            public void onPageSelected(int position) {
                pageSelected(position);
                changeTabStyle(position);

            }

            @Override
            public void onPageScrollStateChanged(int state) {
                pageScrollStateChanged(state);
            }
        });

        return this;

    }

    /**
     * 切换tab样式
     *
     * @param index
     */
    protected void changeTabStyle(int index) {
        for (int i = 0; i < viewGroup.getChildCount(); i++) {
            View view = viewGroup.getChildAt(i);
            if (i == index) {
                view.setBackgroundResource(R.drawable.bottom_border);
            } else {
                view.setBackgroundResource(R.color.colorWhite);
            }
        }
    }

    /**
     * 切换显示的page
     *
     * @param index
     */
    protected void changeShowPag(int index) {

        if (index < fragmentItemList.size()) {
            viewPager.setCurrentItem(index);
            changeTabStyle(index);
        }

    }

}
