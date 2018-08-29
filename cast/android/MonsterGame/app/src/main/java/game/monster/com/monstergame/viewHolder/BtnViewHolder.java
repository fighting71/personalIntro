package game.monster.com.monstergame.viewHolder;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

import butterknife.BindView;
import butterknife.ButterKnife;
import game.monster.com.monstergame.R;

/**
 * Created by DELL on 2018/7/30.
 */

public class BtnViewHolder extends BaseViewHolder {

    @BindView(R.id.btn_item)
    public Button btnItem;

    public BtnViewHolder(LayoutInflater layoutInflater, ViewGroup parent) {
        super(layoutInflater.inflate(R.layout.item_btn, parent, false));
        ButterKnife.bind(this, itemView);
    }

}
