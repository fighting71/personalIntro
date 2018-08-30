package game.monster.com.monstergame.learning.utils;

import android.util.Log;

import game.monster.com.monstergame.cusInterface.IGetFunction;

/**
 * @author yj
 * @remark
 * @since 2018/8/30
 */

public class CommandUtils {

    public static String tag = "net.learning.utils";

    public static void countTime(IGetFunction<Object> runnable) {

        long startTime = System.currentTimeMillis();//记录开始时间
        Object result = "error";
        try {
            result = runnable.run();
        } catch (Exception e) {
            e.printStackTrace();
        }

        long endTime = System.currentTimeMillis();//记录结束时间

        long excTime = (endTime - startTime);

        Log.i(tag, "》》》》》》》》》》》》》》》》》执行时间：" + excTime + "ms");
        Log.i(tag, "-----------------------------------------------result:" + result);

    }


}
