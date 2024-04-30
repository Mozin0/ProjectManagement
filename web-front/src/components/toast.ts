import { toast } from "./ui/use-toast";

export function createToast(objectName: string, typeName: string) {
  toast({
    title: `Added ${objectName} to ${typeName}`,
    description: `Your ${typeName} has been created successfully!`,
    duration: 3000,
  });
}

export function updateToast(objectName: string, typeName: string) {
  toast({
    title: `Updated ${objectName} ${typeName}`,
    description: `Your ${typeName} has been updated successfully!`,
    duration: 3000,
  });
}

export function deleteToast(objectName: string, typeName: string) {
  toast({
    title: `Deleted ${objectName} From ${typeName}`,
    description: `Your ${typeName} has been deleted successfully!`,
    duration: 3000,
  });
}

export function errorToast(objectName: string, typeName: string, deadline?: Date) {
  toast({
    title: "Error",
    description:
      !objectName && !deadline
        ? `Please enter a ${typeName} name and select a deadline date.`
        : !objectName
        ? `Please enter a ${typeName} name.`
        : "Please select a deadline date.",
    duration: 3000,
    variant: "destructive",
  });
}
