
> 稳定的排序

## 冒泡排序 ##

图片示例：

![](https://upload.wikimedia.org/wikipedia/commons/3/37/Bubble_sort_animation.gif)

code:

	/// <summary>
    /// 比较相邻的元素。如果第一个比第二个大，就交换他们两个。
    /// 对每一对相邻元素作同样的工作，从开始第一对到结尾的最后一对。这步做完后，最后的元素会是最大的数。
    /// 针对所有的元素重复以上的步骤，除了最后一个。
    /// 持续每次对越来越少的元素重复上面的步骤，直到没有任何一对数字需要比较。
    /// </summary>
    /// <param name="source"></param>
    /// <param name="compareFunc"></param>
    /// <returns></returns>
	public IEnumerable<T> Sort(IEnumerable<T> source, Func<T, T, bool> compareFunc)
    {
     	T temp;

        //swap
        // n. 交换；交换之物
        // vt.与...交换；以...作交换
        // vi.交换；交易
        bool swapped;

        var arr = source.ToArray();

        for (int i = 0; i < arr.Length; i++)
        {
            swapped = false;
            for (int j = 0; j < arr.Length - i - 1; j++)//遍历无序区段
            {
                if (compareFunc.Invoke(arr[j], arr[j + 1]))//查看是否需要置换
                {
                    temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                    if (!swapped)
                        swapped = true;
                }
            }

            if (!swapped)//若无序区段不存在则直接结束
                break;

        }

        return arr;
	}

----------

![稳定的排序](https://i.imgur.com/EIYyHUq.png)

----------

图示比较：

![简要比较](https://i.imgur.com/8S0mUnP.png)

...维基上挺详细的，不清楚的直接看代码注释吧

----------

author:monster

since:10/12/2018 2:22:40 PM 

direction:sort arithmetic

source:[https://zh.wikipedia.org/wiki/%E6%8E%92%E5%BA%8F%E7%AE%97%E6%B3%95](https://zh.wikipedia.org/wiki/%E6%8E%92%E5%BA%8F%E7%AE%97%E6%B3%95 "维基百科")