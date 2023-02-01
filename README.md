# Kogane Check Error Log Scope

エラーや例外、アサートが発生したかどうかを確認できるスコープ

## 使用例

```cs
using Kogane;
using UnityEngine;

public sealed class Example : MonoBehaviour
{
    private void Start()
    {
        using var scope = new CheckErrorLogScope();

        Debug.LogError( "ピカチュウ" );

        if ( scope.IsError )
        {
            // ...
        }
    }
}
```