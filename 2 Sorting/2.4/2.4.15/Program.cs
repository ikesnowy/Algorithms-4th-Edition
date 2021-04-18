// 参见 MinPQ 中的 IsMinHeap 方法
// bool IsMinHeap(int k)
// {
//     if (k > this.n)
//         return true;
//     int left = 2 * k;
//     int right = 2 * k + 1;
//     if (left <= this.n && Greater(k, left))
//         return false;
//     if (right <= this.n && Greater(k, right))
//         return false;

//     return IsMinHeap(left) && IsMinHeap(right);
// }

return;