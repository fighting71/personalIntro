package game.monster.com.monstergame.adapter;

import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.content.pm.ResolveInfo;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import java.util.Collections;
import java.util.List;

import game.monster.com.monstergame.MainActivity;
import game.monster.com.monstergame.R;
import game.monster.com.monstergame.viewHolder.BtnViewHolder;

/**
 * Created by DELL on 2018/7/30.
 */

public class AppListAdapter extends BaseAdapter {

    Class viewHolderClass;

    List<PackageInfo> packageInfoList;

    public AppListAdapter(Context context,List<PackageInfo> list) {
        super(context);
        packageInfoList = list;
    }

    @Override
    public RecyclerView.ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {

        RecyclerView.ViewHolder viewHolder = new BtnViewHolder(mLayoutInflater,parent);
        return viewHolder;

    }

    @Override
    public void onBindViewHolder(RecyclerView.ViewHolder holder, int position) {

        ApplicationInfo applicationInfo = packageInfoList.get(position).applicationInfo;

        if(holder instanceof BtnViewHolder){
            BtnViewHolder btnViewHolder = (BtnViewHolder) holder;
            btnViewHolder.btnItem.setText(applicationInfo.loadLabel(context.getPackageManager()));

//            btnViewHolder.btnItem.setOnClickListener(new View.OnClickListener() {
//                @Override
//                public void onClick(View v) {
//
//                    try {
//                        //开启前需要在AndroidManifest.xml进行配置。
//                        ComponentName componet = new ComponentName(applicationInfo.packageName, applicationInfo.className);
//                        //pkg 就是第三方应用的包名
//                        //cls 就是第三方应用的进入的第一个Activity
//                        Intent intent = new Intent();
//                        intent.setComponent(componet);
//                        intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
//                        context.startActivity(intent);
//                    }catch (Exception e){
//                        Log.d(AppListAdapter.this.getClass().getName(),e.toString());
//                    }
//
//                }
//            });

        }

    }

    @Override
    public int getItemCount() {
        return packageInfoList.size();
    }
}
