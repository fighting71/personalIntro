package game.monster.com.monstergame.learning.entity;

/**
 * @author yj
 * @remark https://zh.wikipedia.org/wiki/矩阵
 * @since 2018/8/29
 */

public class Martix implements Cloneable {

    private Integer[][] instance;
    private int rowNum;
    private int colNum;

    public Integer[][] getInstance() {
        return instance;
    }

    public int getRowNum() {
        return rowNum;
    }

    public int getColNum() {
        return colNum;
    }

    public Martix(int rowNum, int colNum) {
        this.rowNum = rowNum;
        this.colNum = colNum;
        instance = new Integer[rowNum][colNum];
    }

    public Martix(Integer[][] martix) {
        instance = martix;
        rowNum = martix.length;
        colNum = martix[0].length;
    }

    /**
     * 倒置
     *
     * @return
     */
    public Martix inversion() {
        Integer[][] newMartix = new Integer[getColNum()][getRowNum()];

        for (int i = 0; i < colNum; i++) {
            for (int j = 0; j < rowNum; j++) {

                newMartix[i][j] = instance[j][i];

            }
        }

        return new Martix(newMartix);

    }

    /**
     * @param martix
     * @return
     * @throws Exception 两个矩阵的乘法仅当第一个矩阵A的列数(column)和另一个矩阵B的行数(row)相等时才能定义
     */
    public Martix multiply(Martix martix) throws Exception {

        if (this.getColNum() != martix.getRowNum()) {//两个矩阵的乘法仅当第一个矩阵A的列数(column)和另一个矩阵B的行数(row)相等时才能定义
            throw new Exception("行列不匹配，无法进行操作");
        }

        Integer[][] newMartix = new Integer[martix.colNum][this.rowNum];

        for (int i = 0; i < rowNum; i++) {

            for (int k = 0; k < martix.getColNum(); k++) {

                Integer result = 0;

                for (int j = 0; j < colNum; j++) {

                    result = result + instance[i][j] * martix.get(j, k);

                }

                newMartix[i][k] = result;

            }

        }

        return new Martix(newMartix);

    }

    /**
     * @param martix
     * @return
     * @throws Exception 矩阵行列需匹配
     */
    public Martix add(Martix martix) throws Exception {
        if (this.getRowNum() != martix.getRowNum() || this.getColNum() != martix.getColNum()) {
            throw new Exception("行列不匹配，无法进行操作");
        }

        for (int i = 0; i < rowNum; i++) {
            for (int j = 0; j < colNum; j++) {

                martix.set(
                        instance[i][j] + martix.get(i, j),
                        i, j
                );

            }
        }

        return martix;

    }

    public void set(Integer info, int rowIndex, int colIndex) {

        instance[rowIndex][colIndex] = info;

    }

    public Integer get(int rowIndex, int colIndex) {

        return instance[rowIndex][colIndex];

    }

}
