package game.monster.com.monstergame.avtivity;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;

import com.google.gson.Gson;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

import game.monster.com.monstergame.R;


/**
 * 一维战舰
 */
public class ArithmeticGameActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_arithmetic_game);

        init();

        start();

    }

    Integer n = 80;
    Integer k = 15;
    Integer a = 4;

    protected Integer[] panel;

    public Gson gson = new Gson();

    protected void init(){

        // 1 * n 格子

        panel = new Integer[n];

        // 放置k个战舰  战舰的大小为 1 * a  战舰不能相互重叠，也不能相接触。

        int distance = n - k * (a+1);//可空的距离 = 格子数 - 战舰占位数 + 不能相接触的数 》》 小细节 是否考虑战舰放置在首位两处 如果是 则可空距离会上调 + 1

        Random random = new Random();

        for (int i= 0;i<n;i++){
            //计算空隙
            int randNum = random.nextInt(distance);

            for (int j = 0;j<a;j++,i++){
                panel[i] = 1;//放置战舰
            }

            for (int j = 0;j<randNum+1;j++,i++){
                //空隙
            }

            //减少可空距离
            distance = distance - randNum;

        }

        Log.d(this.getClass().getName(),gson.toJson(panel));

    }

    //进行点名
    protected boolean run(int searchIndex){

        //如何有 则说hit 否则 说miss
//        return panel[searchIndex] !=null;

        //爱丽丝喜欢撒谎。他每次都会告诉鲍博miss。

        return false;

    }

    protected void start(){
        //帮助鲍博证明爱丽丝撒谎了，请找出哪一步之后爱丽丝肯定撒谎了。

        boolean nonLie = false;

        List<Integer> stochasticList = new ArrayList<>();

        Random rand = new Random();

        int randNum = 0;

        int distance = n - k * (a+1);

        while (nonLie){

            // =-= 从第一位开始 逐次递增进行猜测 若当位数超过了可空距离时 任然是miss 则肯定是说谎了。。。
            //细节 可空距离 = 总位数 - 战舰数 * (战舰大小 + 1) - 猜测次数 - +1;

            //从第(战舰的大小-1) 开始

            //增量 1 -> 战舰大小

            //10 3 2  - 》 2

            //20 3 3 - >  2  5  8 11   11     3 1 3 1 3  -- > 4

        }

    }

}
