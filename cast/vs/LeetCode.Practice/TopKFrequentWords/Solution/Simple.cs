using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopKFrequentWords.Solution
{
    public class Simple
    {
        /// <summary>
        /// Runtime: 372 ms, faster than 26.36% of C# online submissions for Top K Frequent Words.
        /// lambda.,
        /// </summary>
        /// <param name="words"></param>
        /// <param name="k">需要排序的个数</param>
        /// <returns></returns>
        public IList<string> TopKFrequent(string[] words, int k)
        {
            //step1:统计每个word出现的次数
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (var t in words)
            {
                if (dictionary.ContainsKey(t))
                    dictionary[t]++;
                else
                    dictionary.Add(t, 1);
            }

            //step2: 根据出现次数进行排序 并获取前k个word
            return dictionary.OrderByDescending((pair => pair.Value)).ThenBy((pair => pair.Key))
                .Select((pair => pair.Key)).Take(k).ToList();
        }

        public IList<string> Optmize(string[] words, int k)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (var t in words)
            {
                if (dictionary.ContainsKey(t))
                    dictionary[t]++;
                else
                    dictionary.Add(t, 1);
            }

            List<string> list = new List<string>();
            foreach (var item in dictionary)
            {
                
            }

            return null;
        }

        //        /// <summary>
        //        /// source:https://leetcode.com/problems/top-k-frequent-words/discuss/108346/My-simple-Java-solution-using-HashMap-and-PriorityQueue-O(nlogk)-time-and-O(n)-space
        //        /// </summary>
        //        /// <param name="words"></param>
        //        /// <param name="k"></param>
        //        /// <returns></returns>
        //        public List<String> OtherSolution(String[] words, int k)
        //        {
        //
        //            List<String> result = new LinkedList<>();
        //            Map<String, Integer> map = new HashMap<>();
        //            for (int i = 0; i < words.length; i++)
        //            {
        //                if (map.containsKey(words[i]))
        //                    map.put(words[i], map.get(words[i]) + 1);
        //                else
        //                    map.put(words[i], 1);
        //            }
        //
        //            PriorityQueue<Map.Entry<String, Integer>> pq = new PriorityQueue<>(
        //                (a, b)->a.getValue() == b.getValue() ? b.getKey().compareTo(a.getKey()) : a.getValue() - b.getValue()//权值比较方法
        //            );//优先队列的作用是能保证每次取出的元素都是队列中权值最小的
        //
        //            for (Map.Entry<String, Integer> entry: map.entrySet())
        //            {
        //                pq.offer(entry);//插入队列
        //                if (pq.size() > k)
        //                    pq.poll();//移除最小的权值
        //            }
        //
        //            while (!pq.isEmpty())
        //                result.add(0, pq.poll().getKey());//拿出的永远是最小的 故从开头进行添加
        //
        //            return result;
        //        }

    }
}