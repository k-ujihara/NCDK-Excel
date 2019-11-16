NCDK-Excel: Cheminformatics function for Excel
==============================================

NCDK-Excel is Add-in for enabling cheminformatics functions in Excel worksheet.

Getting Started
---------------

Input a formula beginning with "NCDK_" or "RDKit_" in the Excel cell like the followings.
- =NCDK_ECFP4("c1ccccc1C")
- =NCDK_XLogP("c1ccccc1C")
- =RDKit_MACCSFingerprint("c1ccccc1C")

Impoting SDF
- Click "Import SDF" button in Add-ins tab in ribbon and select SD file. It gives a new worksheet imported the SDF.

Generate picture from SMILES/InChI/MOL block
- Select cells and click "Generate Picture".

Screenshot
----------

![screenshot](image/NCDK-Excel-Worksheet-1.png?raw=true)

How to Install
--------------

From installer: Execute NCDK-Excel.msi to install NCDK-Excel and then enable add-in by File > Options > Add-ins > Manage: COM-Add-ins > GO... > check 'NCDK for Excel' if required.

Build
-----

Open the solution file by Visual Studio 2017 and build all.
Installer will be generated.

### NCDK functions

AcidicGroupCount
APol
AromaticAtomsCount
AromaticBondsCount
AtomCount
AutocorrelationCharge
AutocorrelationMass
AutocorrelationPolarizability
BasicGroupCount
BCUT
BondCount
BPol
CarbonTypes
ChiChain
ChiCluster
ChiPathCluster
ChiPath
CPSA
EccentricConnectivityIndex
FMF
FractionalPSA
FractionalCSP3
FSP3
FragmentComplexity
GravitationalIndex
HBondAcceptorCount
HBondDonorCount
HybridizationRatio
JPlogP
KappaShapeIndices
KierHallSmarts
LargestChain
LargestPiSystem
LengthOverBreadth
LongestAliphaticChain
MannholdLogP
MDE
MomentOfInertia
PetitjeanNumber
PetitjeanShapeIndex
RotatableBondsCount
RuleOfFive
SmallRing
TPSA
VABC
VAdjMa
WeightedPath
WHIM
WienerNumbers
XLogP
ZagrebIndex
ECFP0
ECFP2
ECFP4
ECFP6
FCFP0
FCFP2
FCFP4
FCFP6
ALogP
AMolarRefractivity
MolecularWeight
ExactMas
SMILES
InChI
InChIKey
MolBlock
Tanimoto

### RDKit Functions

MACCSFingerprint
LayeredFingerprint
HashedAtomPairFingerprint
HashedTopologicalTorsionFingerprint
PatternFingerprint
RDKFingerprint
AtomPairFingerprint
TopologicalTorsionFingerprint
Chi0n
Chi0v
Chi1n
Chi1v
Chi2n
Chi2v
Chi3n
Chi3v
Chi4n
Chi4v
Kappa1
Kappa2
Kappa3
LabuteASA
MolLogP
MolMR
ExactMW
FractionCSP3
HallKierAlpha
LipinskiHBA
LipinskiHBD
NumAliphaticCarbocycles
NumAliphaticHeterocycles
NumAliphaticRings
NumAmideBonds
NumAromaticCarbocycles
NumAromaticHeterocycles
NumAromaticRings
NumBridgeheadAtoms
NumHBA
NumHBD
TPSA
NumRotatableBonds
NumHeteroatoms
NumHeterocycles
NumRings
NumSaturatedCarbocycles
NumSaturatedHeterocycles
NumSaturatedRings
NumSpiroAtoms
BalabanJ
FormalCharge
AtomStereoCenters
UnspecifiedAtomStereoCenters
MolFormula
CXSmiles
InchiKey
MolBlock
PDBBlock
Smarts
Smiles
TanimotoSimilarity
AllBitSimilarity
AsymmetricSimilarity
BraunBlanquetSimilarity
CosineSimilarity
DiceSimilarity
KulczynskiSimilarity
McConnaugheySimilarity
OnBitSimilarity
RusselSimilarity
SokalSimilarity
TverskySimilarity

Copyright (c) 2018-2019 Kazuya Ujihara
