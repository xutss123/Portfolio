//
//  ViewController.swift
//  collectionView
//
//  Created by ISSD on 18/12/2018.
//  Copyright © 2018 ISSD. All rights reserved.
//

import UIKit
import UICircularProgressRing


class ViewController: UIViewController, UICollectionViewDelegate, UICollectionViewDataSource {
    
  
    var cages = [cageClass]()
    var selectedCell:Int!
    var timerOn = Timer()
    var timerOff = Timer()
    var currentP:String!
    var allPreset = [[Preset]]()
    var selctedCageprograssValue = [Int]();
    var count = 0
    
   
    
    @IBOutlet weak var cageCollectionView: UICollectionView!

  
    func collectionView(_ collectionView: UICollectionView, numberOfItemsInSection section: Int) -> Int {
        return cages.count
    }
    
    func collectionView(_ collectionView: UICollectionView, cellForItemAt indexPath: IndexPath) -> UICollectionViewCell {
       
        let cell = collectionView.dequeueReusableCell(withReuseIdentifier: "Cell", for: indexPath) as! CageCellCollectionViewCell
    
    
      cages[indexPath.item].cageImage = cell.cageImage
      cages[indexPath.item].cageSwitch = cell.cageSwitchOff
      cages[indexPath.item].cagePrograss = cell.prograssCircle
      cell.backgroundColor = UIColor.red
      cell.presetBtn.addTarget(self, action: #selector(setPreset), for: .touchUpInside)
      cell.lampBtn.addTarget(self, action: #selector(setLamp), for: .touchUpInside)
      cell.currentCagePreset.text = currentP
    
        

        
      cell.cageSwitchOff.addTarget(self, action: #selector(toggel(_:)), for: .valueChanged)
      cell.cageSwitchOff.tag = indexPath.item

        return cell
        
    }
    @objc func setPreset(){
       
        self.performSegue(withIdentifier: "setPresetPage", sender: self)
        

    }
    @objc func setLamp(){
        
        self.performSegue(withIdentifier: "setLampPage", sender: self)
        
        
    }
    
   

  
    @objc func toggel(_ sender: UISwitch) {
        
         selectedCell = sender.tag
        print(selectedCell)
         let progressRing:UICircularProgressRing = cages[selectedCell].cagePrograss
        
        if sender.isOn{
            print("I used")
           // self.testfunc()
        self.runTimerToTurnOnLamp()
            cages[selectedCell].cageView.backgroundColor = UIColor(red: 0/255, green: 142/255, blue: 19/255, alpha: 1.0)
            cages[selectedCell].cageImage.image = UIImage.init(named: "onLamp")
            progressRing.innerRingColor = UIColor.green
            
            progressRing.startProgress(to: 100, duration: 22.0) {
                
                print("All lamps are on")
          }
            
        }
        else{
            self.runTimerToTurnOffLamp()
            cages[selectedCell].cageView.backgroundColor = UIColor.darkGray
            progressRing.innerRingColor = UIColor.red;
            cages[selectedCell].cageImage.image = UIImage.init(named: "offLamp")
            progressRing.innerRingColor = UIColor.red
            progressRing.startProgress(to: 0, duration: 22.0) {

                print("All lamps are off")

            }

        }
    }
    
   
    override func viewDidLoad() {
        super.viewDidLoad()
       
        self.cageCollectionView.delegate = self
        self.cageCollectionView.dataSource = self
        
        //layout
        var layout = self.cageCollectionView.collectionViewLayout as! UICollectionViewFlowLayout
        layout.sectionInset = UIEdgeInsets(top: 0, left: 5, bottom: 0, right: 5)
        layout.minimumLineSpacing = 5
        let width = UIScreen.main.bounds.width
        print("hello")
        print(currentP)


    }
    
   
  
    
    func returnCages()-> Array<cageClass>{
        
        return cages
    }
    
    public func turnOnLamp(turnUp:Int)
    {
        var UrlRequest = URLRequest(url: URL(string: "http:192.168.1.131/api/MwFVMApwzRx-tmuK8mgSUZkVVcDs-8sEUXBbZskl/lights/4/state")!)
        
        UrlRequest.httpMethod = "PUT"
        UrlRequest.setValue("application/Json", forHTTPHeaderField: "Content-Type")
        UrlRequest.setValue("MwFVMApwzRx-tmuK8mgSUZkVVcDs-8sEUXBbZskl", forHTTPHeaderField: "Authorization Bearer ")
        
        let jsonDictonary = NSMutableDictionary()
        jsonDictonary.setValue(true, forKey: "on")
        jsonDictonary.setValue(turnUp, forKey: "bri")

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
    
    
    public func turnOffLamp()
    {
        var UrlRequest = URLRequest(url: URL(string: "http:192.168.1.131/api/MwFVMApwzRx-tmuK8mgSUZkVVcDs-8sEUXBbZskl/lights/4/state")!)
        
        UrlRequest.httpMethod = "PUT"
        UrlRequest.setValue("application/Json", forHTTPHeaderField: "Content-Type")
        UrlRequest.setValue("MwFVMApwzRx-tmuK8mgSUZkVVcDs-8sEUXBbZskl", forHTTPHeaderField: "Authorization Bearer ")
        
        let jsonDictonary = NSMutableDictionary()
        jsonDictonary.setValue(false, forKey: "on")
        
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
    
    func runTimerToTurnOnLamp() {
        
      self.timerOn = Timer.scheduledTimer(timeInterval: 2, target: self,   selector: (#selector(ViewController.countUp)), userInfo: nil, repeats: true)
        
    }
  
    func runTimerToTurnOffLamp() {
        
        self.timerOff = Timer.scheduledTimer(timeInterval: 2, target: self,   selector: (#selector(ViewController.countDown)), userInfo: nil, repeats: true)
        
    }
    
     @objc func countDown(){
       
            cages[selectedCell].prograssValue -= 25
            self.turnOnLamp(turnUp: cages[selectedCell].prograssValue)
        
        if  cages[selectedCell].prograssValue == 0{
            timerOff.invalidate()
            self.turnOffLamp()

        }
        
    }
    
    @objc func countUp(){
        
//     cages[selectedCell].prograssValue += 25
//        self.turnOnLamp(turnUp: cages[selectedCell].prograssValue)
//
//        if  cages[selectedCell].prograssValue == 250{
//            timerOn.invalidate()
//        }
        var test = self.returnProgressValueOfCage(presetName: self.currentP)
        cages[selectedCell].prograssValue = test[count]
        self.turnOnLamp(turnUp: cages[selectedCell].prograssValue)
        print(cages[selectedCell].prograssValue)
        self.count += 1

    }
   
    
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        if let destination = segue.destination as? AddCageController
        {
            destination.addedCages = self.cages
            
        }
        if let destination = segue.destination as? PresetController
        {
            
            
             destination.cages = self.cages
           
        }
        
    }
    
    func returnProgressValueOfCage(presetName:String)->Array<Int>{
        
        self.selctedCageprograssValue.removeAll()
        for preset in self.allPreset{
            
            for p in preset{
                
                if presetName == p.Name{
                    
                    self.selctedCageprograssValue = p.Values
                }
            }
        }
        return self.selctedCageprograssValue
        
    }
    
  
        
    
    
   
}

