package game.monster.com.monstergame.fragment;

import android.os.Bundle;
import android.support.annotation.NonNull;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.Unbinder;
import game.monster.com.monstergame.R;
import game.monster.com.monstergame.cusInterface.ISetFunction;

public class News2Fragment extends LazyFragment {


    @BindView(R.id.tv_confirm)
    TextView tvConfirm;
    Unbinder unbinder;

    public static LazyFragment newInstance(@NonNull ISetFunction<Bundle> setFunction) {
        LazyFragment fragment = new News2Fragment();
        Bundle args = new Bundle();
        setFunction.run(args);
        fragment.setArguments(args);
        return fragment;
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        Log.i(getClass().getName(), "onCreateView");
        // Inflate the layout for this fragment
        rootView = inflater.inflate(R.layout.fragment_news2, container, false);

        unbinder = ButterKnife.bind(this, rootView);
        return rootView;
    }

    @Override
    protected void loadData() {

        hasLoding = () -> true;
        tvConfirm.setText("已加载数据");

    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        unbinder.unbind();
    }
}
