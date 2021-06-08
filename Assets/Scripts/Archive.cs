/*
 * From ENEMY.cs
 * 
 *  IEnumerator InvokeMovement()
    {
        while (true)
        {
            RandomMovement();
            yield return new WaitForSeconds(2);
        }
    }
    private void RandomMovement() // need to find the top 3(?) closest waypoints and go to it
    {
        float choice = UnityEngine.Random.Range(-1, 1);
        int[] valid = {-1, 1};
        int factorX = UnityEngine.Random.Range(0, 1);
        int factorY = UnityEngine.Random.Range(0, 1);
        if (health >= 3 && !PauseMenu.isPaused && !CutsceneManager.isCutscene)
        {
            movement = new Vector2(choice * valid[factorX], choice * valid[factorY]); // where to move to

            anim.SetFloat("Horizontal", (float)Math.Round(choice));
            anim.SetFloat("Speed", (float)Math.Round(choice));

            if ((float)Math.Round(choice) < 0.1f) // if random val is < 0.5, then idle
            {
                moveSpeed = 0f;
            }
            else
            {
                moveSpeed = 2f;
            }
        }
        else if (!PauseMenu.isPaused && !CutsceneManager.isCutscene)
        {
            int moveX = UnityEngine.Random.Range(0, 1);
            int moveY = UnityEngine.Random.Range(0, 1);
            movement = new Vector2(valid[moveX], valid[moveY]); // where to move to

            anim.SetFloat("Horizontal", (float)Math.Round(Math.Abs(choice)));
            anim.SetFloat("Speed", 1);

            moveSpeed = 3f;
        }
    }
 * 
 */