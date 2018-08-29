package game.monster.com.monstergame.arithmetic;

import java.util.ArrayList;
import java.util.List;
import java.util.regex.Pattern;

/**
 * @author yj
 * @remark
 * @since 2018/8/22
 */

public class ExpressionArthmetic {

    /**
     * 通过表达式获取
     *
     * @param expression
     * @return
     */
    public String getResult(String expression) {

        boolean canGetResult = canGetResult(expression);

        if(canGetResult){
            //通过char 解析来计算 ，，，
//            ScriptEngineManager manager = new ScriptEngineManager();
        }

        return canGetResult(expression) ? "能够计算结果" : "不能计算结果";

    }

    public void getExpressResult(String expression){

        String opt;

        boolean hasPriority = false;

        List<Double> valueList = new ArrayList<>();

        double empty;

        for (int i = 0;i<expression.length() - 1 ;i++){
            opt = expression.substring(i,i+1);

            if(hasPriority){

            }

            if(opt.equals("(")){
                hasPriority = true;
            }else if(opt.equals(")")){
                hasPriority = false;
            }

        }

    }

    public boolean canGetResult(String expression) {

        String regex = "[+|\\-|x|/|0-9|(|)]*";
        return Pattern.matches(regex, expression);

    }

}
