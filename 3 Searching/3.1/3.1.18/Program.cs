// 设 key 为目标键。
// 算法初始时 lo = 0, hi = n-1，数组已排序。
// 当找到目标键时，返回的下标 mid 显然是正确的。
// （0...a[mid-1] 都小于 a[mid]，同时 a[mid]=key）
// 
// 接下来证明：当目标键不存在时，lo 可以代表小于 key 的键的个数。
// 由算法内容，当循环退出时，一定有 lo 和 hi 交叉，即 lo > hi。
// 考虑最后一次循环，必然执行了 lo = mid + 1 或者 hi = mid - 1。
// 即最后一次循环之后 lo = mid + 1 > hi 或 hi = mid - 1 < lo。
// 又由于 mid = (lo + hi) / 2，代入有：
// 即 (lo + hi)/2 + 1 > hi 或 (lo + hi) / 2 - 1 < lo
// (lo - hi) / 2 + 1 > 0 或 (hi - lo) / 2 - 1 < 0
// (hi - lo) / 2 < 1
// hi - lo < 2
// 由于 hi 和 lo 都是整数，故有 hi - lo <= 1
// 
// 由算法的内容可以得出，最后一次循环时，
// 下标小于 lo 的元素都小于 key，下标大于 hi 的元素都大于 key
// 且下标小于 lo 的元素正好有 lo 个 （0...lo-1)。
//
// 当 lo = hi 时，mid = lo
// 若 key > lo，则 lo = lo + 1，即 a[lo] 本身也小于 key。
// 若 key < lo，lo 不变，即 a[lo] 就是大于 key 的第一个元素。
// 
// 当 lo = hi - 1 时，mid = lo
// 若 key > lo，则 lo = lo + 1 = hi，变为上一种情况。
// 若 key < lo，则 hi = lo - 1，a[lo] 是大于 key 的第一个元素。
// 
// 综上，Rank() 是正确的。

return;