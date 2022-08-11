using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
public class BossQuizGameLogic : MonoBehaviour
{
    /// <summary>
    ///Creating an array for the questions that can edited and changed within the inspector
    /// </summary>
    public Question[] questions;
    /// <summary>
    /// On startup all questions are contained within a list and as the player answers them they are removed so they cannot be repeated.
    /// Having it set to static means that it can persist. When the scene reloads for the next question, it remembers what was removed from the list and what remains within it.
    /// </summary>
    private static List<Question> unansweredQuestions;
    /// <summary>
    /// This variable pulls a random question for the user from the list
    /// </summary>
    private Question currentQuestion;
    /// <summary>
    /// Sets the current question to the text object to display the question to the user
    /// </summary>
    [SerializeField]
    private Text factText;
    /// <summary>
    /// Creates references to the text to tell the user if they are wrong or right, these are reference in order to create the animations for when the user answers true or false
    /// Score text keeps track of the score and displays to the user so they can consistently see their total every question. A correct answer add's 1, A incorrect answer subtracts 1
    /// </summary>
    [SerializeField]
    private Text trueAnswerText;
    [SerializeField]
    private Text falseAnswerText;
    /// <summary>
    /// Creates a reference for our animations so that they can be attached properly and triggered at the correct time
    /// </summary>
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float timeBetweenQuestions = 1f;
    /// <summary>
    /// Default score total for the start of the quiz
    /// </summary>
    public static int bossCurrentHP = 100;
    public static int currentHP = 100;
    /// <summary>
    /// On startup all questions from the array are moved into the list and it gives the user a random question
    /// Every time the game is reset it calls upon the start method so it needs to check the question count
    /// </summary>
    public ProtectionBarController healthBar;
    public ProtectionBarController bossHealthBar;
    public bool bossShoot, bossHit, playerShoot, playerHit;
    public Animator bossAnimations, playerAnimations;
    public GameObject player, boss;
    void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }
        SetCurrentQuestion();
    }
    void Update()
    {
        healthBar.GetComponent<ProtectionBarController>().healthSlider.value = currentHP;
        bossHealthBar.GetComponent<ProtectionBarController>().bossHealthSlider.value = bossCurrentHP;
    }
    /// <summary>
    /// This function takes a random number within the array that corresponds to a question and sets it to the current question to ask the user 
    /// </summary>
    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];
        //Displays question text
        factText.text = currentQuestion.fact;
        //Checks if the user was correct or wrong and displays message accordingly
        if (currentQuestion.isTrue)
        {
            trueAnswerText.text = "CORRECT";
            falseAnswerText.text = "WRONG";
        }
        else
        {
            trueAnswerText.text = "WRONG";
            falseAnswerText.text = "CORRECT";
        }

    }
    /// <summary>
    /// removes the current question from the list so the user isn't asked more than once
    /// The game will then wait for a few seconds to tell the user if they are right or wrong
    /// It will then reload the scene for the next question to be displayed
    /// </summary>
    /// <returns></returns>
    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);
        yield return new WaitForSeconds(timeBetweenQuestions);
        if (unansweredQuestions.Count > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SceneManager.LoadScene("BossQuizEndGameScreen");
            Debug.Log("End of quiz");
        }
    }
    /// <summary>
    /// These two functiuons check if the answer is correct or wrong and displays to the user 
    /// </summary>
    public void UserSelectTrue()
    {
        animator.SetTrigger("True");
        if (currentQuestion.isTrue)
        {
            Debug.Log("Correct!");
            bossCurrentHP -= 10;
            bossHit = true;
            playerShoot = true;
            if (playerShoot)
            {
                playerAnimations.SetBool("PlayerShoot", true);
                player.GetComponent<FireBullet>().Shoot();
            }
            else
            {
                playerAnimations.SetBool("PlayerShoot", false);
            }
            if (bossHit)
            {
                bossAnimations.SetBool("Hit", true);
            }
            else
            {
                bossAnimations.SetBool("Hit", false);
            }
        }
        else
        {
            Debug.Log("Wrong!");
            currentHP -= 10;
            bossShoot = true;
            playerHit = true;
            if (bossShoot)
            {
                bossAnimations.SetBool("BossShoot", true);
                boss.GetComponent<FireBullet>().Shoot();
            }
            else
            {
                bossAnimations.SetBool("BossShoot", false);
            }
            if (playerHit)
            {
                playerAnimations.SetBool("PlayerHit", true);
            }
            else
            {
                playerAnimations.SetBool("PlayerHit", false);
            }
        }
        StartCoroutine(TransitionToNextQuestion());
    }
    public void UserSelectFalse()
    {
        animator.SetTrigger("False");
        if (!currentQuestion.isTrue)
        {
            Debug.Log("Correct!");
            bossCurrentHP -= 10;
            bossHit = true;
            playerShoot = true;
            if (playerShoot)
            {
                playerAnimations.SetBool("PlayerShoot", true);
                player.GetComponent<FireBullet>().Shoot();
            }
            else
            {
                playerAnimations.SetBool("PlayerShoot", false);
            }
            if (bossHit)
            {
                bossAnimations.SetBool("Hit", true);
            }
            else
            {
                bossAnimations.SetBool("Hit", false);
            }
        }
        else
        {
            Debug.Log("Wrong!");
            currentHP -= 10;
            bossShoot = true;
            playerHit = true;
            if (bossShoot)
            {
                bossAnimations.SetBool("BossShoot", true);
                boss.GetComponent<FireBullet>().Shoot();
            }
            else
            {
                bossAnimations.SetBool("BossShoot", false);
            }
            if (playerHit)
            {
                playerAnimations.SetBool("PlayerHit", true);
            }
            else
            {
                playerAnimations.SetBool("PlayerHit", false);
            }
        }
        StartCoroutine(TransitionToNextQuestion());
    }
}
