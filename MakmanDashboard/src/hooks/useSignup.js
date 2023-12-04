import { useMutation } from '@tanstack/react-query';
import { useNavigate } from 'react-router-dom';
import { signup } from '../services/apiAuth';

export function useSignup() {
  const navigate = useNavigate();

  const { mutate: signupUser, isLoading } = useMutation({
    mutationFn: signup,
    onSuccess: () => {
      navigate('/posts');
    },
  });

  return { signupUser, isLoading };
}
