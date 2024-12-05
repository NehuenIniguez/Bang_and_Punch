using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FirebaseAuthWrapper : MonoBehaviour
{
    public void SignInAnonimous()
    {
        FirebaseWebGL.Scripts.FirebaseBridge.FirebaseAuth.SignInAnonymously(
            gameObject.name, 
            nameof(OnSignInSuccess), 
            nameof(OnSignInFailure));
    }
    public void SignInWithGoogle()
    {
        FirebaseWebGL.Scripts.FirebaseBridge.FirebaseAuth.SignInWithGoogle(
            gameObject.name, 
            nameof(OnSignInSuccess), 
            nameof(OnSignInFailure));
    }

    private void OnSignInSuccess(string result)
    {
        Debug.Log("Sign in successful: " + result);
        SceneManager.LoadScene("MainMenu");
    }

    private void OnSignInFailure(string error)
    {
        Debug.LogError("Sign in failed: " + error);
    }
}


