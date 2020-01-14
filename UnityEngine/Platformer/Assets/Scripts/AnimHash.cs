using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimHash
{
    //readonly는 읽기 전용 접근자로 상수와는 달리 함수에서의 최초변환이 가능하다.(자세한 사항은 검색바람. 해당 내용에 오류가 있을 수 있음)
    public static readonly int Walk = Animator.StringToHash("IsWalk");
    public static readonly int Melee = Animator.StringToHash("IsMelee");
    public static readonly int Jump = Animator.StringToHash("Jump");
    public static readonly int StageNumber = Animator.StringToHash("ScreenNumber");
    public static readonly int Dead = Animator.StringToHash("IsDead");
}
