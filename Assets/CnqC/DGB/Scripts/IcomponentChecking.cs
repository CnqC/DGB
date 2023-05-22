using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnqC.DGB;

// Vì ta sử dụng rất nhiều Script khác nhau , nên t sẽ tạo ra 1 interFace để sử dụng cho các Script đó

public interface IcomponentChecking
{
    bool IscomponentNull(); // kiêm tra các Coponent được ta gọi ra có null hay không
}
