package game.monster.com.monstergame.avtivity;

import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.text.TextUtils;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import butterknife.BindView;
import butterknife.ButterKnife;
import game.monster.com.monstergame.R;
import game.monster.com.monstergame.arithmetic.ExpressionArthmetic;

public class ArthmeticExpressionActivity extends AppCompatActivity {

    @BindView(R.id.toolbar)
    Toolbar toolbar;
    @BindView(R.id.et_expression)
    EditText etExpression;
    @BindView(R.id.btn_run)
    Button btnRun;
    @BindView(R.id.et_result)
    EditText etResult;
    @BindView(R.id.fab)
    FloatingActionButton fab;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_arthmetic_expression);
        ButterKnife.bind(this);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                        .setAction("Action", null).show();
            }
        });

        bindEvent();

    }

    ExpressionArthmetic arthmetic = new ExpressionArthmetic();

    private void bindEvent() {

        btnRun.setOnClickListener(v -> {

            String expression = etExpression.getText().toString();

            if(!TextUtils.isEmpty(expression)){
                String result = arthmetic.getResult(expression);
                etResult.setText(result);
            }

        });

    }

}
