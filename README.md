eksctl utils associate-iam-oidc-provider --cluster myapp-eks-cluster --approve

eksctl create iamserviceaccount --name ebs-csi-controller-sa --namespace kube-system --cluster myapp-eks-cluster --attach-policy-arn arn:aws:iam::aws:policy/service-role/AmazonEBSCSIDriverPolicy --approve --role-only --role-name AmazonEKS_EBS_CSI_DriverRole

eksctl create addon --name aws-ebs-csi-driver --cluster myapp-eks-cluster --service-account-role-arn arn:aws:iam::943725333913:role/AmazonEKS_EBS_CSI_DriverRole --force

kubectl create secret generic aws-secret --namespace kube-system --from-literal "key_id=${AWS_ACCESS_KEY_ID}" --from-literal "access_key=${AWS_SECRET_ACCESS_KEY}"

eksctl delete addon --name aws-ebs-csi-driver --cluster myapp-eks-cluster

eksctl delete iamserviceaccount --name ebs-csi-controller-sa --namespace kube-system --cluster myapp-eks-cluster 

eksctl create addon --name aws-ebs-csi-driver --cluster myapp-eks-cluster --service-account-role-arn arn:aws:iam::$(aws sts get-caller-identity --query Account --output text):role/AmazonEKS_EBS_CSI_DriverRole --force
