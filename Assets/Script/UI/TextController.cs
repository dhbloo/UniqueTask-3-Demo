using UnityEngine;
using System.Collections;


public class TextController : MonoBehaviour
{
    public GameObject text_pool_prefab;

    private GameObject text_pool_obj;
    private TextPool text_pool;

    private int key;

    public float tip_time = 2.0f;

    // Use this for initialization
    void Start()
    {
        text_pool_obj = Instantiate(text_pool_prefab);
        text_pool_obj.transform.SetParent(transform.parent);
        text_pool = text_pool_obj.GetComponent<TextPool>();

        key = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (key == 0)
            return;

        switch (key)
        {
            case 1:
                text_pool.AddDialogue2("同伴", "这里就是古王国遗址了，听说贪婪的国王将宝贝放到第三层了。");
                text_pool.AddDialogue2("你", "大概很不容易找到吧，或许地下还会有机关？");
                text_pool.AddDialogue2("同伴", "据我的情报……这个国王生前痴迷数学，所以他很大可能不会布置机关，而让你做几道数学题。");
                text_pool.AddDialogue2("你", "哈哈，哈，这不是开玩笑的地方。");
                text_pool.AddDialogue2("同伴", "我可没开玩笑哦。");
                text_pool.AddDialogue2("同伴", "时间也不早了，你该进去了，我在这等着你，以防外面有什么变故，用通讯机联系。");
                text_pool.AddDialogue2("你", "好的。");
                text_pool.AddTip(tip_time, "通过WASD行动");
                text_pool.AddTip(tip_time, "E键可以与物品发生互动。");
                text_pool.AddTip(tip_time, "shift键可以冲刺。");
                break;

            case 2:
                text_pool.AddDialogue2("同伴", "你去哪？这里才是入口。");
                break;

            case 3:
                text_pool.AddDialogue1(2.0f, "有一阵阴风从里面吹出来了……");
                break;

            case 4:
                text_pool.AddDialogue1(2.0f, "好黑……希望能快点找到宝藏。");
                break;

            case 5:
                text_pool.AddDialogue2("你", "这是……什么？！！");
                text_pool.AddDialogue2("你", "味道好大，还有令人厌恶的紫色。");
                text_pool.AddDialogue2("你", "而且比我在空间站吃的汤还黏。");
                text_pool.AddDialogue2("同伴", "小心。");
                text_pool.AddTip(tip_time, "你不能在泥潭上冲刺。");
                break;

            case 6:
                text_pool.AddDialogue1(2.0f, "\"前面这是个开关？\"");
                break;

            case 7:
                text_pool.AddDialogue2("你", "这个建筑的电力还没有枯竭……看来用的是核能源，不过他们的政治制度为什么这么落后？");
                text_pool.AddDialogue2("同伴", "的确，这个星球上怪异的事情又很多。");
                break;

            case 8:
                text_pool.AddDialogue2("你", "这是……一副壁画？上面还有文字，让我打开翻译器……");
                text_pool.AddDialogue2("你", "画的似乎是国王和数学家们。文字是：……最纯粹的……最自然的数……我的挚爱……？");
                text_pool.AddDialogue2("同伴", "什么意思？");
                text_pool.AddDialogue2("你", "不知道。");
                break;

            case 9:
                text_pool.AddDialogue2("你", "这个门似乎锁住了……去别的地方看看吧。");
                break;

            case 10:
                text_pool.AddDialogue2("你", "破旧的墙壁，它的基底似乎已经被腐蚀的差不多了。");
                text_pool.AddTip(tip_time, "腐烂墙壁可以被击破。");
                break;
        }

        key = 0;
    }

    private void OnDestroy()
    {
        Destroy(text_pool_obj);
    }

    public void StartText(int _key)
    {
        key = _key;
    }
}
