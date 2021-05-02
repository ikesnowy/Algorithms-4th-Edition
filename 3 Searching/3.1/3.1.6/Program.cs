// FrequencyCounter 的官方实现：https://algs4.cs.princeton.edu/31elementary/FrequencyCounter.java.html
// 每个单词都会被放进符号表一次，
// 因此 Put 的调用次数就等于单词总数 W + 1（注意寻找最大值的时候有一次 Put 调用）
// 对于重复的单词，输入时会先调用 Get 获得当前计数之后再 Put 回去。
// 寻找最大值时，对于符号表中的每个键值都会调用两次 Get。
// 重复的单词数量 = (W - D)
// 因此 Get 方法的调用次数 = (W - D) + 2D

return;