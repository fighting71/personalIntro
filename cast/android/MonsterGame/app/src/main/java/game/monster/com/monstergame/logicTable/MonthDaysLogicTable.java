package game.monster.com.monstergame.logicTable;

/**
 * Created by DELL on 2018/7/31.
 */

public class MonthDaysLogicTable {

    /**
     * 逻辑表
     */
    public Integer[] list = {30,31,28};

    /**
     * 获取天数
     * @param month 月份
     * @return
     */
    public Integer GetDays(int month){
        if(month == 2){//2月特殊处理
            return list[month];
        }else{
            return list[month%2];
        }
    }

}
