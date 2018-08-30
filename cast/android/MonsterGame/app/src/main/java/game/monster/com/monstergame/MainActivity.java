package game.monster.com.monstergame;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;

import java.util.HashMap;
import java.util.Map;

import butterknife.BindView;
import butterknife.ButterKnife;
import butterknife.OnClick;
import game.monster.com.monstergame.avtivity.AppInteractiveActivity;
import game.monster.com.monstergame.avtivity.ArithmeticGameActivity;
import game.monster.com.monstergame.avtivity.ArthmeticExpressionActivity;
import game.monster.com.monstergame.avtivity.CutPictureActivity;
import game.monster.com.monstergame.avtivity.EnvironmentActivity;
import game.monster.com.monstergame.avtivity.ServiceFabricIntroActivity;
import game.monster.com.monstergame.avtivity.ViewPagerDemo2Activity;
import game.monster.com.monstergame.avtivity.ViewPagerDemo3Activity;
import game.monster.com.monstergame.avtivity.ViewPagerDemo4Activity;
import game.monster.com.monstergame.avtivity.ViewPagerDemoActivity;
import game.monster.com.monstergame.cusInterface.IClickListener;
import game.monster.com.monstergame.cusRealize.clickListener.SkipListener;
import game.monster.com.monstergame.learning.LReverseInteger;

public class MainActivity extends AppCompatActivity {

    protected Map<Integer, IClickListener> clickListenerHashMap;

    @BindView(R.id.btn_searchConfig)
    Button btnSearchConfig;

    @BindView(R.id.btn_appInteractive)
    Button btnAppInteractive;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        ButterKnife.bind(this);

        initListener();

//        MartixL martixL = new MartixL();
//        try {
//            martixL.test();
//        } catch (Exception e) {
//            e.printStackTrace();
//        }

//        LArithmeticOne arithmeticOne = new LArithmeticOne();
//        arithmeticOne.test();

//        test();

//        LReverseInteger lReverseInteger = new LReverseInteger();
//        lReverseInteger.test();

    }

    private void test() {

        int num = 0;

        countTime(() -> {

            try {
                int temp = 3 / num;
            } catch (Exception e) {
                e.printStackTrace();
            }

        });

        countTime(() -> {

            try {
                int temp = num / 3;
            } catch (Exception e) {
                e.printStackTrace();
            }

        });

    }

    private void countTime(Runnable runnable) {
        long startTime = System.currentTimeMillis();//记录开始时间

        runnable.run();//此处为你调用的方法

        long endTime = System.currentTimeMillis();//记录结束时间

        long excTime = (endTime - startTime);

        System.out.println("执行时间：" + excTime + "ms");

    }

    private void initListener() {

        clickListenerHashMap = new HashMap<>();

        clickListenerHashMap.put(R.id.btn_searchConfig, new SkipListener(EnvironmentActivity.class, intent -> {
        }));

        clickListenerHashMap.put(R.id.btn_appInteractive, new SkipListener(AppInteractiveActivity.class, intent -> {
            intent.putExtra(this.getClass().getName(), R.id.btn_appInteractive);
        }));

        clickListenerHashMap.put(R.id.btn_arithmetic_game, new SkipListener(ArithmeticGameActivity.class, intent -> {
            intent.putExtra(this.getClass().getName(), R.id.btn_arithmetic_game);
        }));

        clickListenerHashMap.put(R.id.btn_view_pager_demo, new SkipListener(ViewPagerDemoActivity.class, intent -> {
            intent.putExtra(this.getClass().getName(), R.id.btn_view_pager_demo);
        }));

        clickListenerHashMap.put(R.id.btn_view_pager_demo2, new SkipListener(ViewPagerDemo2Activity.class, intent -> {
            intent.putExtra(this.getClass().getName(), R.id.btn_view_pager_demo2);
        }));

        clickListenerHashMap.put(R.id.btn_view_pager_demo3, new SkipListener(ViewPagerDemo3Activity.class, intent -> {
            intent.putExtra(this.getClass().getName(), R.id.btn_view_pager_demo3);
        }));

        clickListenerHashMap.put(R.id.btn_view_pager_demo4, new SkipListener(ViewPagerDemo4Activity.class, intent -> {
            intent.putExtra(this.getClass().getName(), R.id.btn_view_pager_demo4);
        }));

        clickListenerHashMap.put(R.id.btn_arithmetic_expression, new SkipListener(ArthmeticExpressionActivity.class, intent -> {
            intent.putExtra(this.getClass().getName(), R.id.btn_arithmetic_expression);
        }));

        clickListenerHashMap.put(R.id.btn_defind_picture, new SkipListener(CutPictureActivity.class, intent -> {
            intent.putExtra(this.getClass().getName(), R.id.btn_defind_picture);
        }));

        clickListenerHashMap.put(R.id.btn_service_fabric, new SkipListener(ServiceFabricIntroActivity.class, intent -> {
            intent.putExtra(this.getClass().getName(), R.id.btn_service_fabric);
        }));

    }

    @OnClick({R.id.btn_searchConfig, R.id.btn_appInteractive, R.id.btn_arithmetic_game, R.id.btn_view_pager_demo
            , R.id.btn_view_pager_demo2, R.id.btn_view_pager_demo3, R.id.btn_view_pager_demo4
            , R.id.btn_arithmetic_expression, R.id.btn_defind_picture, R.id.btn_service_fabric})
    public void onViewClicked(View view) {

        int id = view.getId();

        if (clickListenerHashMap.containsKey(id)) {
            clickListenerHashMap.get(id).run(view, this);
        }

    }

}
