package game.monster.com.monstergame.cusRealize.clickListener;

import android.app.Activity;
import android.content.Intent;
import android.view.View;

import game.monster.com.monstergame.cusInterface.IClickListener;
import game.monster.com.monstergame.cusInterface.ISetFunction;

/**
 * Created by DELL on 2018/7/30.
 */

public class SkipListener implements IClickListener {

    private Class targetActity;

    private ISetFunction<Intent> setFunction;

    private Integer skipFlag;

    public static final Integer DefaultFlag = 0x001;

    public SkipListener(Class targetActity, ISetFunction<Intent> setFunction) {
        this(targetActity,setFunction,DefaultFlag);
    }

    public SkipListener(Class<? extends Object> targetActity, ISetFunction<Intent> setFunction, Integer skipFlag) {
        this.targetActity = targetActity;
        this.setFunction = setFunction;
        this.skipFlag = skipFlag;
    }

    @Override
    public void run(View view, Activity context) {

        Intent intent = new Intent(context,targetActity);
        if(setFunction!=null){
            setFunction.run(intent);
        }
        context.startActivityForResult(intent,skipFlag);

    }
}
