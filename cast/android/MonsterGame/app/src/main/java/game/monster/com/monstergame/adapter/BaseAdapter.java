package game.monster.com.monstergame.adapter;

import android.content.Context;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.ViewGroup;

/**
 * Created by DELL on 2018/7/30.
 */

public abstract class BaseAdapter<T extends RecyclerView.ViewHolder> extends  RecyclerView.Adapter<T> {

    LayoutInflater mLayoutInflater;

    Context context;

    public BaseAdapter(Context context) {
        this.context = context;
        this.mLayoutInflater = LayoutInflater.from(context);
    }
}
