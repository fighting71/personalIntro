package game.monster.com.monstergame;

import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;

import com.google.gson.Gson;

import java.util.HashMap;
import java.util.Hashtable;
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
import game.monster.com.monstergame.learning.deal.simple.RomantoInteger;
import game.monster.com.monstergame.learning.utils.CommandUtils;

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

//        PalindromeNumber palindromeNumber = new PalindromeNumber();
//
//        palindromeNumber.otherIsPalindrome(1234321);

        RomantoInteger romantoInteger = new RomantoInteger();

        Gson gson = new Gson();

        CommandUtils.countTime(() -> {

            Map<String, Integer> map = new Hashtable<>();

            for (int i = 0; i < 100; i++) {

                map.put("IXCABCVFCM", romantoInteger.optmizeRomanToInt("IXCABCVFCM"));
                map.put("III", romantoInteger.optmizeRomanToInt("III"));
                map.put("IV", romantoInteger.optmizeRomanToInt("IV"));
                map.put("IX", romantoInteger.optmizeRomanToInt("IX"));
                map.put("LVIII", romantoInteger.optmizeRomanToInt("LVIII"));
                map.put("MCMXCIV", romantoInteger.optmizeRomanToInt("MCMXCIV"));
                map.put("VISAIMCXI", romantoInteger.optmizeRomanToInt("VISAIMCXI"));

            }

            return gson.toJson(map);

        });//18 ms  80ms  50ms

        CommandUtils.countTime(() -> {

            Map<String, Integer> map = new Hashtable<>();

            for (int i = 0; i < 100; i++) {

                map.put("IXCABCVFCM", romantoInteger.otherRomanToInt("IXCABCVFCM"));
                map.put("III", romantoInteger.otherRomanToInt("III"));
                map.put("IV", romantoInteger.otherRomanToInt("IV"));
                map.put("IX", romantoInteger.otherRomanToInt("IX"));
                map.put("LVIII", romantoInteger.otherRomanToInt("LVIII"));
                map.put("MCMXCIV", romantoInteger.otherRomanToInt("MCMXCIV"));
                map.put("VISAIMCXI", romantoInteger.otherRomanToInt("VISAIMCXI"));
                map.put("IVIV", romantoInteger.otherRomanToInt("IVIV"));//not roman number

            }

            return gson.toJson(map);

        });// 1ms  9ms

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
