using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Formats.Alembic.Importer;

public class AlembicController : MonoBehaviour
{
    private AlembicStreamPlayer alembicStreamPlayer;
    private bool isPlaying = false;
    private bool isReversing = false;
    private bool repDone = false;

    void Start()
    {
        alembicStreamPlayer = GetComponent<AlembicStreamPlayer>();

        if (alembicStreamPlayer == null)
        {
            Debug.LogError("AlembicStreamPlayer component not found on this GameObject.");
        }
    }

    void Update()
    {
        if (alembicStreamPlayer != null)
        {
            if (repDone && !isPlaying)
            {
                // Start playing the animation forward
                alembicStreamPlayer.CurrentTime = isReversing ? alembicStreamPlayer.Duration : 0.0f;
                isPlaying = true;
            }

            if (isPlaying)
            {
                
                // Update the animation time
                if (!isReversing)
                {
                    alembicStreamPlayer.CurrentTime += Time.deltaTime * 2;
                    if (alembicStreamPlayer.CurrentTime >= alembicStreamPlayer.Duration)
                    {
                        // Reverse the direction
                        alembicStreamPlayer.CurrentTime = alembicStreamPlayer.Duration;
                        isReversing = true;
                    }
                }
                else
                {
                    alembicStreamPlayer.CurrentTime -= Time.deltaTime * 2;
                    if (alembicStreamPlayer.CurrentTime <= 0.0f)
                    {
                        // Stop playing the animation
                        alembicStreamPlayer.CurrentTime = 0.0f;
                        isReversing = false;
                        isPlaying = false;
                        repDone = false;
                    }
                }

                alembicStreamPlayer.UpdateImmediately(alembicStreamPlayer.CurrentTime);
            }
        }
    }

    public void repUpdate(){
        repDone = true;
    }
}
