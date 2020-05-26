using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : BasePopup
{
    [SerializeField] private Text numEnemiesValue;
    [SerializeField] private Slider difficultySlider;
    [SerializeField] private Button ok;
    [SerializeField] private Button cancel;
    [SerializeField] private OptionsPopup options;
    // Start is called before the first frame update
 

    void Start()
    {

        Debug.Log("sp.start()");
        //this.gameObject.SetActive(false);

        difficultySlider.value = PlayerPrefs.GetInt("difficulty", (int)difficultySlider.value);
        Messenger<float>.Broadcast(GameEvent.DIFFICULTY_CHANGED, difficultySlider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void Open()
    {
        
        
        base.Open();
        // we need this here because when we hit cancel, we don't reset the difficulty to what it was
        // when we first opened the dialog.
        difficultySlider.value = PlayerPrefs.GetInt("difficulty", (int)difficultySlider.value);

    }


    override public void Close()
    {
       
        base.Close();
        options.Open();
       

    }


    public void OnOKButton()
    {
       PlayerPrefs.SetInt("difficulty", (int)difficultySlider.value);
        Messenger<float>.Broadcast(GameEvent.DIFFICULTY_CHANGED, difficultySlider.value);
        Close();
    }

    public void OnCancelGameButton()
    {

        // Application.Quit();
        Close();
    }

    public void OnDifficultyValue(float difficulty)
    {
        numEnemiesValue.text = difficulty.ToString();
    }


   

}
