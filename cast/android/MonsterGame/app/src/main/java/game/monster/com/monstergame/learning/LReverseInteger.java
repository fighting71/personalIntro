package game.monster.com.monstergame.learning;

import com.google.gson.Gson;

import java.util.ArrayList;
import java.util.List;

import game.monster.com.monstergame.learning.deal.ReverseInteger;
import game.monster.com.monstergame.learning.utils.CommandUtils;

/**
 * @author yj
 * @remark
 * @since 2018/8/30
 */

public class LReverseInteger {

    public void test() {

//        Failed sending reply to debugger: Broken pipe
        // 有毒 执行两个就不行  而且必须开线程使用 不开线程也不行
        //Waiting for a blocking GC ProfileSaver
        //my bug =......
        new Thread(() -> {

            ReverseInteger reverseInteger = new ReverseInteger();
            CommandUtils.countTime(() ->
                    reverseInteger.newReverse(546546872)
            );//0ms

            CommandUtils.countTime(() ->
                    reverseInteger.otherReverse(546546872)
            );//0ms

            CommandUtils.countTime(() ->
                    reverseInteger.reverse(546546872)
            );//1ms

            CommandUtils.countTime(() ->
                    reverseInteger.newReverse(-546546872)
            );//0ms

            CommandUtils.countTime(() ->
                    reverseInteger.otherReverse(-546546872)
            );//0ms

            CommandUtils.countTime(() ->
                    reverseInteger.reverse(-546546872)
            );//1ms

            Gson gson = new Gson();


            CommandUtils.countTime(() -> {

                List<Integer> resultList = new ArrayList<>();

                for (int i = 0; i < 40; i++) {
                    resultList.add(reverseInteger.otherReverse(445646568));
                    resultList.add(reverseInteger.otherReverse(-546546872));
                    resultList.add(reverseInteger.otherReverse(454564575));
                    resultList.add(reverseInteger.otherReverse(-546546872));
                    resultList.add(reverseInteger.otherReverse(456546878));
                    resultList.add(reverseInteger.otherReverse(-546546872));
                    resultList.add(reverseInteger.otherReverse(467457676));
                }

                return gson.toJson(resultList);
            });//2ms  3ms  0ms 12ms  31ms

            CommandUtils.countTime(() -> {

                List<Integer> resultList = new ArrayList<>();

                for (int i = 0; i < 40; i++) {
                    resultList.add(reverseInteger.newReverse(445646568));
                    resultList.add(reverseInteger.newReverse(-546546872));
                    resultList.add(reverseInteger.newReverse(454564575));
                    resultList.add(reverseInteger.newReverse(-546546872));
                    resultList.add(reverseInteger.newReverse(456546878));
                    resultList.add(reverseInteger.newReverse(-546546872));
                    resultList.add(reverseInteger.newReverse(467457676));
                }

                return gson.toJson(resultList);
            });//4ms  3ms(跟顺序有关？)  23ms 56ms =-= 有毒吧 40ms 无疑问了 这个比较慢。



        }).start();

    }

}
