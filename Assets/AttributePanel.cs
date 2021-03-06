using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributePanel : MonoBehaviour
{
    public Transform AllatributeLocation;
    public int numberOfAttribute;
    public float Max, Min,ValueofY;
    public Toggle.ToggleEvent toggleEvent;

    public GameObject AttributeCreated,OptionCreated;
    public float intialAttributYpos = 0.8f,intialoptionXpos=4.5f;
    public static List<Toggle> AllToggles;
public ArabicText NoAttributs;
    // Start is called before the first frame update
    void Start()
    {

if(loadimageFromApi.ProductRequst==null){
 if(GetDetailsProduct.ProductRequst.data.attributes.Count==0)

{
  if (UPDownMenu.LanguageValue == 1)
        {
NoAttributs.Text="No Attributes For This Product";
}

else

{
NoAttributs.Text="لايوجد تفاصيل لهذا المنتج";


}



}
else
{
NoAttributs.gameObject.SetActive(false);

}
            numberOfAttribute = GetDetailsProduct.ProductRequst.data.attributes.Count;
            foreach (ProductAttribute p in GetDetailsProduct.ProductRequst.data.attributes)
            {
                AttributeCreated = GameObject.Instantiate(Resources.Load<GameObject>("DetailsPanel/AttributeTemplete"), AllatributeLocation);
                AttributeCreated.name = p.id.ToString();
                AttributeCreated.transform.localPosition = new Vector3(0, intialAttributYpos, 0);

                AttributeCreated.GetComponent<AttributeForDetailsMenu>().AttributeName.Text = p.name;
                if (p.selection_type != "single")
                {
                    AttributeCreated.GetComponent<AttributeForDetailsMenu>().isMoreSelect = true;

                }
                else
                {
                    AttributeCreated.GetComponent<AttributeForDetailsMenu>().isMoreSelect = false;
                }
                AttributeCreated.GetComponent<AttributeForDetailsMenu>().numberofOptions = p.options.Count;
                foreach (ProductOption optionss in p.options)
                {
              
                    OptionCreated = GameObject.Instantiate(Resources.Load<GameObject>("DetailsPanel/OptionTemplet"), AttributeCreated.GetComponent<AttributeForDetailsMenu>().OptionsPanel.transform);
                    OptionCreated.transform.localPosition = new Vector3(intialoptionXpos, 0, 0);
                    OptionCreated.GetComponent<OptionForAttribute>().NameOption.Text = optionss.name;

      
              OptionCreated.GetComponent<OptionForAttribute>().PriceOption.Text = optionss.price +"\n" +" K.D";

                   OptionCreated.name = optionss.id.ToString();
                
                
                  
                
                OptionCreated.GetComponent<Toggle>().onValueChanged = toggleEvent;
                    intialoptionXpos -= 1;
                }
                intialAttributYpos -= .5f;
intialoptionXpos=4.5f;
            }

            ValueofY = -.3f;

            if (numberOfAttribute <= 3)
            {
                Min = Max = -.3f;

            }
            else
            {
                Min = -.3f;
                Max = -.3f + ((numberOfAttribute - 3) * .5f);
            }

//////////////////////////////////////
}
else{


       if(loadimageFromApi.ProductRequst.data.attributes.Count==0)

{
  if (UPDownMenu.LanguageValue == 1)
        {
NoAttributs.Text="No Attributes For This Product";
}

else

{
NoAttributs.Text="لايوجد تفاصيل لهذا المنتج";


}



}
else
{
NoAttributs.gameObject.SetActive(false);

}
            numberOfAttribute = loadimageFromApi.ProductRequst.data.attributes.Count;
            foreach (ProductAttribute p in loadimageFromApi.ProductRequst.data.attributes)
            {
                AttributeCreated = GameObject.Instantiate(Resources.Load<GameObject>("DetailsPanel/AttributeTemplete"), AllatributeLocation);
                AttributeCreated.name = p.id.ToString();
                AttributeCreated.transform.localPosition = new Vector3(0, intialAttributYpos, 0);

                AttributeCreated.GetComponent<AttributeForDetailsMenu>().AttributeName.Text = p.name;
                if (p.selection_type != "single")
                {
                    AttributeCreated.GetComponent<AttributeForDetailsMenu>().isMoreSelect = true;

                }
                else
                {
                    AttributeCreated.GetComponent<AttributeForDetailsMenu>().isMoreSelect = false;
                }
                AttributeCreated.GetComponent<AttributeForDetailsMenu>().numberofOptions = p.options.Count;
                foreach (ProductOption optionss in p.options)
                {
              
                    OptionCreated = GameObject.Instantiate(Resources.Load<GameObject>("DetailsPanel/OptionTemplet"), AttributeCreated.GetComponent<AttributeForDetailsMenu>().OptionsPanel.transform);
                    OptionCreated.transform.localPosition = new Vector3(intialoptionXpos, 0, 0);
                    OptionCreated.GetComponent<OptionForAttribute>().NameOption.Text = optionss.name;

      
              OptionCreated.GetComponent<OptionForAttribute>().PriceOption.Text = optionss.price +"\n" +" K.D";

                   OptionCreated.name = optionss.id.ToString();
                
                
                  
                
                OptionCreated.GetComponent<Toggle>().onValueChanged = toggleEvent;
                    intialoptionXpos -= 1;
                }
                intialAttributYpos -= .5f;
intialoptionXpos=4.5f;
            }

            ValueofY = -.3f;

            if (numberOfAttribute <= 3)
            {
                Min = Max = -.3f;

            }
            else
            {
                Min = -.3f;
                Max = -.3f + ((numberOfAttribute - 3) * .5f);
            }

}
    }
    public void UpScroll()
    {
      

        if (ValueofY < Max )
        {
            ValueofY += .5f;

            AllatributeLocation.localPosition = new Vector3(0, ValueofY, 0);

        }


        
    }

    public void DownScroll()
    {
      

        if ( ValueofY > Min+.1f)
        {
            ValueofY -= .5f;

            AllatributeLocation.localPosition = new Vector3(0, ValueofY, 0);

        }



    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
