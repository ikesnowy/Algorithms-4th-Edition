/*   
*   对象的固定开销用 Object 表示
*   a.Accumulator(1.2.4.3 节给出的实现)
*      = int * 1 + double + Object * 1
*      = 4 * 1 + 8 + 16 * 1 = 32
*   b.Transaction
*      = string * 1 + Date * 1 + double * 1 + Object * 1
*      = (40 + 16 + 4 + 4 + 2N) * 1 + (8 + 32) * 1 + 8 * 1 + 16 * 1
*      = 128 + 2N
*   c.FixedCapacityStackOfStrings
*      = string[] * 1 + string * N + int * 1 +  Object * 1
*      = 24 * 1 + N * (64 + 2C) + 4 * 1 + 16 * 1
*      = N * (64 + 2C) + 44
*      = N * (64 + 2C) + 48（填充）
*   d.Point2D
*      = double * 2 + Object * 1
*      = 8 * 2 + 16 * 1
*      = 32
*   e.Interval1D
*      = double * 2 + Object * 1
*      = 8 * 2 + 16 * 1
*      = 32
*   f.Interval2D
*      = Interval1D * 2 + Object * 1
*      = (8 + 24) * 2 + 16 * 1
*      = 80
*   g.Double
*      = double * 1 + Object * 1
*      = 8 * 1 + 16 * 1
*      = 24
*      
*/

return;