﻿// 官网给出了解答：https://algs4.cs.princeton.edu/24pq/
// 证明：
// 定义叶子结点的高度为 0，根结点的高度为树的高度 h。
// 于是一个结点最多进行 k 次 sink 操作，k 为该结点的高度。
// 那么最大交换次数即为：
// h + 2(h-1) + 4(h-2) + ... + 2^h(0) = 2^(h+1) - h - 2
// 其中满二叉树结点数量 n = 2^(h+1) - 1，代入得
// h^(h+1) - h - 2 = n - (h + 1) <= n
// 于是交换次数小于 n，比较次数为交换次数的两倍小于 2n
// 再证：
// 堆中某个结点最多一路下沉到叶子结点，
// 最大交换次数就是该结点的高度（记叶子结点的高度为 0）。
// 考虑根结点一路下沉到叶子结点上的路线，
// 设为 a0, a1, a2, ... , ak，其中 k 为根结点的高度，a0 是根结点。
// a0 下沉后结点顺序变为 a1, a2, ..., ak, a0。
// 根据下沉的定义，有 a1 > a2 > ... > ak > a0。
// 因此 a1 下沉时不可能与 a2 交换，而会向另一个方向下沉。
// 其余结点同理，可以发现每个结点的下沉路径不会与其他结点重合。
// 一棵完全二叉树共有 N - 1 条边，每访问一条边代表进行了一次交换。
// 故交换次数必定小于 N，比较次数为交换次数的两倍小于 2N。

return;