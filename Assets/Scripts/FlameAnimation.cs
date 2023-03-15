using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class FlameAnimation : MonoBehaviour
{
    [SerializeField] private int lightMode;
    [SerializeField] private AnimationClip[] lightAnimClips;
    [SerializeField] private Animation lightAnims;

    private void Update()
    {
        if (lightMode == 0)
        {
            StartCoroutine(AnimateLight());
        }
    }

    private IEnumerator AnimateLight()
    {
        lightMode = Random.Range(1, 4);
        switch (lightMode)
        {
            case 1:
                lightAnims.Play("FlameAnim1");
                break;
            case 2:
                lightAnims.Play("FlameAnim2");
                break;
            case 3:
                lightAnims.Play("FlameAnim3");
                break;
        }

        yield return new WaitForSeconds(0.99f);
        lightMode = 0;
    }
}
