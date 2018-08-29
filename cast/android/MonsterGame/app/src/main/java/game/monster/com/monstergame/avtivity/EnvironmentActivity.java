package game.monster.com.monstergame.avtivity;

import android.content.pm.PackageInfo;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.widget.Button;

import com.google.gson.Gson;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.OnClick;
import game.monster.com.monstergame.R;
import game.monster.com.monstergame.cusInterface.IClickListener;

public class EnvironmentActivity extends AppCompatActivity {

    @BindView(R.id.btn_searchAppList)
    Button btnSearchAppList;

    protected Map<Integer,IClickListener> clickListenerMap;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_environment);
        ButterKnife.bind(this);

        initListener();

    }

    private void initListener() {

        clickListenerMap = new HashMap<>();

        clickListenerMap.put(R.id.btn_searchAppList,(view,context)->{
            List<PackageInfo> packages = getPackageManager().getInstalledPackages(0);

            Gson gson = new Gson();

            for (PackageInfo item:packages){
                Log.d(this.getClass().getName(), String.format("{appname:<%1$s> packagename:<%2$s> versionName:<%3$s> versionCode:<%4$s>}",
                        item.applicationInfo.loadLabel(getPackageManager()),
                        item.packageName,
                        item.versionName,
                        item.versionCode
                        ));
            }

            Log.d(this.getClass().getName(),"________________success_______________");

        });


        clickListenerMap.put(R.id.btn_searchDetailAppList,(view,context)->{
            List<PackageInfo> packages = getPackageManager().getInstalledPackages(0);

            Gson gson = new Gson();

            for (PackageInfo item:packages){
                Log.d(this.getClass().getName(), gson.toJson(item));

            }

            Log.d(this.getClass().getName(),"________________success_______________");

        });

    }

    @OnClick({R.id.btn_searchAppList,R.id.btn_searchDetailAppList})
    public void onViewClicked(View view){
        int id = view.getId();

        if(clickListenerMap.containsKey(id)){
            clickListenerMap.get(id).run(view,this);
        }
    }

}
