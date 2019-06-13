//
//  ViewController.swift
//  smios phil
//
//  Created by ISSD on 10/01/2019.
//  Copyright © 2019 ISSD. All rights reserved.
//

import UIKit

class ViewController: UIViewController, UIPickerViewDelegate, UIPickerViewDataSource, UITextFieldDelegate  {
    
    
    @IBOutlet weak var slider1: UISlider!
    @IBOutlet weak var slider2: UISlider!
    @IBOutlet weak var slider3: UISlider!
    @IBOutlet weak var slider4: UISlider!
    @IBOutlet weak var slider5: UISlider!
    @IBOutlet weak var slider6: UISlider!
    @IBOutlet weak var slider7: UISlider!
    @IBOutlet weak var slider8: UISlider!
    @IBOutlet weak var slider9: UISlider!
    @IBOutlet weak var slider10: UISlider!
    @IBOutlet weak var slider11: UISlider!
    @IBOutlet weak var slider12: UISlider!
    @IBOutlet weak var slider13: UISlider!
    @IBOutlet weak var slider14: UISlider!
    @IBOutlet weak var slider15: UISlider!
    @IBOutlet weak var slider16: UISlider!
    @IBOutlet weak var slider17: UISlider!
    @IBOutlet weak var slider18: UISlider!
    @IBOutlet weak var slider19: UISlider!
    @IBOutlet weak var slider20: UISlider!
    @IBOutlet weak var slider21: UISlider!
    @IBOutlet weak var slider22: UISlider!
    @IBOutlet weak var slider23: UISlider!
    @IBOutlet weak var slider24: UISlider!
    
    @IBOutlet weak var dropdown: UIPickerView!
    var textTitle = "Default"
    
    var pickerData: [String] = [String]()
    var Winter: [Float] = [Float]()
    var Summer: [Float] = [Float]()
    var Spring: [Float] = [Float]()
    var Fall: [Float] = [Float]()
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        self.dropdown.delegate = self as! UIPickerViewDelegate
        self.dropdown.dataSource = self as! UIPickerViewDataSource
        
        pickerData = ["Spring", "Summer", "Fall", "Winter", "Stormy", "New Zealand Preset"]
        Winter = [20, 22, 23, 24, 26, 28, 33, 35, 40, 45, 48, 55,60, 55, 50, 49, 47, 43,40, 35, 30, 27, 25, 20]
        Summer = [40, 42, 43, 44, 46, 48, 53, 55, 50, 55, 58, 65,70, 75, 70, 69, 67, 63,60, 55, 50, 47, 45, 40]
        Fall = [33, 32, 33, 34, 36, 38, 33, 35, 30, 35, 38, 35,30, 35, 30, 39, 37, 33,30, 35, 30, 37, 35, 30]
        Spring = [0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 65, 70, 75, 80, 85, 90,95, 100, 75, 50, 25, 0]
        
        
        changePreset()
        
    }
    
    func changePreset()
    {
        if textTitle == "Winter"
        {
            setpreset(presetarray: Winter)
        }
        if textTitle == "Summer"
        {
            setpreset(presetarray: Summer)
        }
        if textTitle == "Spring"
        {
            setpreset(presetarray: Spring)
        }
        if textTitle == "Fall"
        {
            setpreset(presetarray: Fall)
        }
    }
    
    func setpreset(presetarray: Array<Float>)
    {
        slider1.value = presetarray[0]
        slider2.value = presetarray[1]
        slider3.value = presetarray[2]
        slider4.value = Float(presetarray[3])
        slider5.value = Float(presetarray[4])
        slider6.value = Float(presetarray[5])
        slider7.value = Float(presetarray[6])
        slider8.value = Float(presetarray[7])
        slider9.value = Float(presetarray[8])
        slider10.value = Float(presetarray[9])
        slider11.value = Float(presetarray[10])
        slider12.value = Float(presetarray[11])
        slider13.value = Float(presetarray[12])
        slider14.value = Float(presetarray[13])
        slider15.value = Float(presetarray[14])
        slider16.value = Float(presetarray[15])
        slider17.value = Float(presetarray[16])
        slider18.value = Float(presetarray[17])
        slider19.value = Float(presetarray[18])
        slider20.value = Float(presetarray[19])
        slider21.value = Float(presetarray[20])
        slider22.value = Float(presetarray[21])
        slider23.value = Float(presetarray[22])
        slider24.value = Float(presetarray[23])
        
//        if weather == "Winter"{
//
//            return self.presetWinter
//            var slider2 = presetWinter[1]
//        }
        
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    // Number of columns of data
    func numberOfComponents(in pickerView: UIPickerView) -> Int {
    return 1
    }
    
    // The number of rows of data
    func pickerView(_ pickerView: UIPickerView, numberOfRowsInComponent component: Int) -> Int {
    return pickerData.count
    }
    
    // The data to return fopr the row and component (column) that's being passed in
    func pickerView(_ pickerView: UIPickerView, titleForRow row: Int, forComponent component: Int) -> String? {
    self.view.endEditing(true)
        textTitle = pickerData[row]
        changePreset()
        return pickerData[row]
    }
    
  
    
}

