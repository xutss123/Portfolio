//
//  CageCellCollectionViewCell.swift
//  collectionView
//
//  Created by ISSD on 18/12/2018.
//  Copyright © 2018 ISSD. All rights reserved.
//

import UIKit
import UICircularProgressRing

class CageCellCollectionViewCell: UICollectionViewCell {
    
    @IBOutlet weak var prograssCircle: UICircularProgressRing!
    
  
    @IBOutlet weak var cageView: UIView!
    
    @IBOutlet weak var cageImage: UIImageView!
    
    @IBOutlet weak var cageSwitchOff: UISwitch!
    
    @IBOutlet weak var presetBtn: UIButton!
    
    @IBOutlet weak var lampBtn: UIButton!

    @IBOutlet weak var currentCagePreset: UILabel!
    
}
