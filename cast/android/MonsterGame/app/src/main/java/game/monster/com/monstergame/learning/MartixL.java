package game.monster.com.monstergame.learning;

import android.util.Log;

import com.google.gson.Gson;

import game.monster.com.monstergame.learning.entity.Martix;

/**
 * @author yj
 * @remark
 * @since 2018/8/29
 */

public class MartixL {

    Gson gson = new Gson();

    private static final String tag = "net.learning.martix";

    public void test() throws Exception {

        Integer[][] martix = new Integer[2][3];
        martix[0] = new Integer[]{1, 3, 1};
        martix[1] = new Integer[]{1, 0, 0};

        Integer[][] addMartix = new Integer[2][3];
        addMartix[0] = new Integer[]{0, 0, 5};
        addMartix[1] = new Integer[]{7, 5, 0};

        Martix add = new Martix(martix).add(new Martix(addMartix));

        Log.i(tag, "矩阵求和：" + gson.toJson(add.getInstance()));

        martix[0] = new Integer[]{1, 0, 2};
        martix[1] = new Integer[]{-1, 3, 1};

        Integer[][] mulMartix = new Integer[3][2];
        mulMartix[0] = new Integer[]{3, 1};
        mulMartix[1] = new Integer[]{2, 1};
        mulMartix[2] = new Integer[]{1, 0};

        Martix multiply = new Martix(martix).multiply(new Martix(mulMartix));
        Log.i(tag, "矩阵求积：" + gson.toJson(multiply.getInstance()));

        Integer[][] inversionMartix = new Integer[2][3];
        inversionMartix[0] = new Integer[]{1, 2, 3};
        inversionMartix[1] = new Integer[]{0, -6, 7};
        Martix inversion = new Martix(inversionMartix).inversion();
        Log.i(tag, "矩阵倒置：" + gson.toJson(inversion.getInstance()));

        Log.i(tag, "矩阵示例：success");

    }

}
