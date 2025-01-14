/// <summary>
/// 一時停止を行う
/// </summary>
interface IPause
{
    /// <summary>
    /// 一時停止させる
    /// </summary>
    void Pause();
    /// <summary>
    /// 再開用
    /// </summary>
    void Resume();
}