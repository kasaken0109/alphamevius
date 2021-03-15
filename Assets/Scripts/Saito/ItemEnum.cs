/// <summary>
/// アイテムのデータ
/// クラフト系の先頭のアイテムよりも前に記述されてるか否かで複数持てるかのフラグ管理をする
/// </summary>
public enum ItemEnum
{
        #region UseItem系
        ///<summary>鶏肉</summary>
        Chicken,
        ///<summary>鹿肉</summary>
        Venison,
        ///<summary>焼き鳥</summary>
        BakedChicken,
        ///<summary>ジビエ</summary>
        Jibie,
        ///<summary>水筒</summary>
        WaterBottle,
        ///<summary>薬草</summary>
        Herbs,
        ///<summary>治癒薬</summary>
        HealingDrug,
        ///<summary>端材</summary>
        EndMaterial,    
        #endregion

        #region 素材系
        ///<summary>ペットボトル</summary>
        PetBottles,
        ///<summary>割れたビン</summary>
        BrokenBottle,
        ///<summary>アルミ缶</summary>
        AluminumCan,
        ///<summary>布切れ</summary>
        PieceOfCloth,
        ///<summary>石</summary>
        Stone,
        ///<summary>枯れた枝</summary>
        DeadBranch,
        ///<summary>藁</summary>
        Straw,
        ///<summary>しなやかな枝</summary>
        SuppleBranches,
        ///<summary>丈夫な枝</summary>
        DurableBranches,
        ///<summary>鉄片</summary>
        IronPiece,
        ///<summary>クマの爪</summary>
        BearClaws,
        ///<summary>鉱石のかけら</summary>
        FragmentOfOre,
        ///<summary>硬い鉱石</summary>
        HardOre,
        ///<summary>丈夫なツタ</summary>
        DurableIvy,
        ///<summary>木材</summary>
        Wood,
        ///<summary>アルミニウム</summary>
        Aluminium,
        ///<summary>ナイフの芯</summary>
        KnifeCore,
        ///<summary>ピッケルの芯</summary>
        PickaxeCore,
        ///<summary>斧の骨子</summary>
        AxeCore,
        
    #endregion

        #region クラフト系(一つしか持てない)
        ///<summary>アルミナイフ</summary>
        AluminiumKnife,
        ///<summary>脆いナイフ</summary>
        FragileKnife,
        ///<summary>小型ナイフ</summary>
        SmallKnife,
        ///<summary>マチェット</summary>
        Machete,
        ///<summary>ピッケル1</summary>
        Pickaxe1,
        ///<summary>ピッケル2</summary>
        Pickaxe2,
        ///<summary>罠</summary>
        Trap,
        ///<summary>斧</summary>
        Axe,
        ///<summary>ハンマー</summary>
        Hammer,
        ///<summary>橋</summary>
        Bridge,
        ///<summary>火</summary>
        Fire,
        #endregion
        
}
public enum ItemStates
{
    UseItem,
    MaterialItem,
    HaveOne,
    EventItem
}


