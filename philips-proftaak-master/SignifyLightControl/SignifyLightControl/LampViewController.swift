//
//  LampViewController.swift
//  SignifyLightControl
//
//  Created by issd on 06/12/2018.
//  Copyright © 2018 issd. All rights reserved.
//

import UIKit

class LampViewController: UIViewController {
 
    @IBOutlet weak var switchLampOne: UISwitch!
    @IBOutlet weak var lampOneView: UIView!
    @IBOutlet weak var switchLampTwo: UISwitch!
    @IBOutlet weak var lampTwoView: UIView!
    @IBOutlet weak var lamp1Image: UIImageView!
    @IBOutlet weak var lamp2Image: UIImageView!
    
    @IBOutlet weak var statusLbl1: UILabel!
    var lamp1URL:String!
    var lamp2URL:String!
    var isLightsOn:Bool!
    var checkString:String!
    @IBOutlet weak var statusLbl2: UILabel!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
       
           print(isLightsOn)
         self.viewsBackground()
        self.lamp1URL = "http:192.168.1.101/api/CSNvXmqqxANlBUJNwYK90LiDjr5oWE8xe3fChIjE/lights/5/state"
        self.lamp2URL = "http:192.168.1.101/api/CSNvXmqqxANlBUJNwYK90LiDjr5oWE8xe3fChIjE/lights/4/state"
        self.switchLampOne.addTarget(self, action: #selector(lamp1Switch(_:)), for: .valueChanged)
        self.switchLampTwo.addTarget(self, action: #selector(lamp2Switch(_:)), for: .valueChanged)
        


      
    }
    
    @objc func lamp1Switch(_ sender: UISwitch) {
        
        if sender.isOn == false{
            
            self.lampControll(lampURL: self.lamp1URL, onStatus: false)
             lampOneView.backgroundColor = UIColor.darkGray
            self.lamp1Image.image = UIImage.init(named: "offLamp")
            self.statusLbl1.text = "OFF"
            
        }
    }
    @objc func lamp2Switch(_ sender: UISwitch) {
        
        if sender.isOn == false{
            
            self.lampControll(lampURL: self.lamp2URL, onStatus: false)
             lampTwoView.backgroundColor = UIColor.darkGray
            self.lamp2Image.image = UIImage.init(named: "offLamp")
            self.statusLbl2.text = "OFF"


        }
    }
    
    func viewsBackground(){
        
//        if let x = UserDefaults.standard.object(forKey: "isLightOn") as? Bool{
//
//            isLightsOn = x
//        }
        if self.checkString == "on"{
            
            self.switchLampOne.isOn = true
            self.switchLampTwo.isOn = true
            lampOneView.backgroundColor = UIColor.green
            lampTwoView.backgroundColor = UIColor.green
            self.lamp1Image.image = UIImage.init(named: "onLamp")
            self.lamp2Image.image = UIImage.init(named: "onLamp")
            self.statusLbl1.text = "ON"
            self.statusLbl2.text = "ON"



            
        }
        
        if self.checkString == "off"{
            
            self.switchLampOne.isOn = false
            self.switchLampTwo.isOn = false
            lampOneView.backgroundColor = UIColor.darkGray
            lampTwoView.backgroundColor = UIColor.darkGray
            self.lampControll(lampURL: lamp1URL, onStatus: false)
            self.lampControll(lampURL: lamp2URL, onStatus: false)
            
            self.lamp1Image.image = UIImage.init(named: "offLamp")
            self.lamp2Image.image = UIImage.init(named: "offLamp")
            
            self.statusLbl1.text = "OFF"
            self.statusLbl2.text = "OFF"





        }
        
    }
    
    func LampsControll(){
        
        
    }
    
    func lampControll(lampURL:String, onStatus:Bool ){
        
        var UrlRequest = URLRequest(url: URL(string: lampURL)!)
        
        UrlRequest.httpMethod = "PUT"
        UrlRequest.setValue("application/Json", forHTTPHeaderField: "Content-Type")
        UrlRequest.setValue("MwFVMApwzRx-tmuK8mgSUZkVVcDs-8sEUXBbZskl", forHTTPHeaderField: "Authorization Bearer ")
        
        let jsonDictonary = NSMutableDictionary()
        jsonDictonary.setValue(onStatus, forKey: "on")
       // jsonDictonary.setValue(turnUp, forKey: "bri")
        
        let jsonData:Data
        do {
            jsonData = try JSONSerialization.data(withJSONObject: jsonDictonary, options: JSONSerialization.WritingOptions())
            UrlRequest.httpBody = jsonData
        } catch {
            print("Error in jsonnnn")
            return
        }
        let session = URLSession.shared
        session.dataTask(with: UrlRequest) { (data, response, error) in
            if let response = response {
                print(response)
            }
            if let data = data {
                do {
                    let json = try JSONSerialization.jsonObject(with: data, options: [])
                    print(json)
                } catch {
                    print(error)
                }
            }
            }.resume()
    }
    
    
    
    
    
   
    
   

}
