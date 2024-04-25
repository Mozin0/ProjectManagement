export const formatDate = (dateString: string): string => {
    const date = new Date(dateString);
    const day = date.getDate().toLocaleString().padStart(2, '0');
    const month = (date.getMonth() + 1).toLocaleString().padStart(2, '0');
    const year = date.getFullYear().toString().slice(-2); 
    return `${day}/${month}/${year}`;
  };
  