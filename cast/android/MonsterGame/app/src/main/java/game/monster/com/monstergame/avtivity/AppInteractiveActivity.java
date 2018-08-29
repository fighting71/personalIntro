package game.monster.com.monstergame.avtivity;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.StaggeredGridLayoutManager;
import android.widget.Adapter;

import butterknife.BindView;
import butterknife.ButterKnife;
import game.monster.com.monstergame.R;
import game.monster.com.monstergame.adapter.AppListAdapter;

public class AppInteractiveActivity extends AppCompatActivity {

    @BindView(R.id.rcv_list)
    RecyclerView rcvList;

    public RecyclerView.Adapter btnListAdapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_app_interactive);
        ButterKnife.bind(this);

        initData();

        initView();

    }

    private void initData() {

        btnListAdapter = new AppListAdapter(this,getPackageManager().getInstalledPackages(0));

    }

    private void initView() {

        rcvList.setLayoutManager(new StaggeredGridLayoutManager(3,
                StaggeredGridLayoutManager.VERTICAL));
        rcvList.setAdapter(btnListAdapter);

    }


}
