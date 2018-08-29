package game.monster.com.monstergame.cusInterface;

import android.app.Activity;
import android.content.Context;
import android.view.View;

/**
 * Created by DELL on 2018/7/30.
 */

@FunctionalInterface
public interface IClickListener {

    public void run(View view, Activity context);

}
